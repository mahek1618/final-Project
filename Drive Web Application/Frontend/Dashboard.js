
const modal = document.querySelector(".modal");

const trigger = document.getElementById("trigger");

const closeButton = document.querySelector(".close-button");

function toggleModal() {

    modal.classList.toggle("show-modal");

}

function windowOnClick(event) {

    if (event.target === modal) {

        toggleModal();

    }

}

trigger.addEventListener("click", toggleModal);

closeButton.addEventListener("click", toggleModal);

window.addEventListener("click", windowOnClick);




    var foldername=document.getElementById("fname");
    var fn= document.getElementById("createbtn");
    fn.addEventListener("click",function(){
         var myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");
        fetch("http://localhost:58659/api/Folder",{
            method:'POST',
    
            // cache: "no-cache",
        
            // credentials: "same-origin",
            headers: myHeaders,
            body:JSON.stringify({
                "FolderName": foldername.value,
                "FCreatedBy": sessionStorage.getItem("Id"),
                "IsDeleted": 0,
                "CreatedAt": new Date().toISOString()
            })
        }).then(res=>{
            return res.text();
        }) .then(data=>console.log(data))
        listFolders();
        // .catch(error=>console.log(error))
    });



    function listFolders() {
  try
  {
    var foldercreate = document.getElementById("main");
    foldercreate.innerHTML = '';
  fetch("http://localhost:58659/api/Folder", {
    method: 'GET'
  })
  .then(response => response.json())
  .then((folders) => {
    console.log(folders);
    folders.forEach(folder => {
    

    var foldercreate = document.getElementById("main");
    // var fol = document.createElement("div");

    var fol = document.createElement("div");
    
    fol.style.width ="270px";
    fol.style.height = "180px";
    fol.style.margin="20px","20px","20px","20px";
     fol.style.background = "wheat";
    fol.style.display="inline-grid";
    fol.style.padding="20px";
    fol.style.borderRadius="12px";




    // fol.setAttribute("id","stylefol");
    // fol.setAttribute("style","height:100px","width:200px","background-color:blue","border-radius:12px","padding: 15px 14px");
    const folname = folder.folderName;
    const foldid=folder.folderId;
    // fold.style.backgroundColor = "red";
    console.log(folname);
    fol.innerHTML =   `<i class="fa fa-folder" aria-hidden="true">
    <button class="addfile" onclick="uploadfile()"></button>
    <a style="font-size:20px;text-decoration: none;position: absolute;cursor: pointer; margin:20px">${folname}</a> 
    </i>
  <button id="upbtn" onclick="uploadfile(${foldid})">Upload</button>
  <i class="fa fa-trash" onclick="deletefolder(${foldid})" style="position:relative;left: 200px;bottom: 25px;">
  </i> `;
   foldercreate.appendChild(fol);
    });
  })
  
  }
  catch(err)
  {
    console.log(err);
  }
}

function onLoad() {
  listFolders();
}

onLoad();

function deletefolder(folder)
{
  var requestOptions = {
    method: 'DELETE',
    body:'raw',
    redirect: 'follow'
  };
  
  fetch("http://localhost:58659/api/Folder/"+folder, requestOptions)
    .then(response => response.text())
    .then(result => console.log(result))
    .catch(error => console.log('error', error));
    location.reload();
}
function uploadfile(foId)
{
sessionStorage.setItem("FolderId",foId);
window.location.href="file.html";
}