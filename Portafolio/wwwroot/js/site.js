// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

document.addEventListener('DOMContentLoaded', function() {
    var form = document.getElementById('contacto-form');
    if (!form) return;

    form.addEventListener('submit', function() {
        var btn = form.querySelector('button[type="submit"]');
        btn.disabled = true;
        btn.classList.add('btn-loading');
        btn.textContent = 'Enviando...';
    });
});
