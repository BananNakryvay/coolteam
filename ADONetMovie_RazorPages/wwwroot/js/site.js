﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(document).ready(function () {
    $("#stable").DataTable();
});

$(".form_datetime").datetimepicker({ format: 'yyyy-mm-dd hh:ii' });
