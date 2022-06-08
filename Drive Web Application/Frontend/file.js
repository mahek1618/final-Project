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

function onLoad() {
    var admin=document.getElementById("usertext");
    admin.innerHTML="Hi"+" "+sessionStorage.getItem("UserName");
  }
  onLoad();
  function logout()
  {
    function logout()
    {
      sessionStorage.clear();
      window.location.href="login.html";
    }
  }
  var userid=sessionStorage.getItem("Id");
  var name=sessionStorage.getItem("UserName");
  var folderid=sessionStorage.getItem("FolderId");
  createfile(
      {

      }
  )
  function uploadfile() {
    debugger;  
    var filepath= document.getElementById("myfile").value;
console.log(filepath);
var myHeaders = new Headers();
myHeaders.append("accept", "*/*");

var formdata = new FormData();
formdata.append("files", filepath.files[0]);

var requestOptions = {
  method: 'POST',
  headers: myHeaders,
  body: formdata,
  redirect: 'follow'
};

fetch("http://localhost:58659/api/Documents/upload", requestOptions)
  .then(response => response.text())
  .then(result => console.log(result))
  .catch(error => console.log('error', error));
  createfolder();
}