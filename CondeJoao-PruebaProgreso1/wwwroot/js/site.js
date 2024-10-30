// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', () =>{
    const boton = document.getElementById("botonAlerta");
    if (boton) {
        boton.addEventListener("click", () => alert("Mi nombre es Joao Conde\nY mi hobbie es jugar fútbol"));
    }
});