<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Destinatarios.aspx.cs" Inherits="LisalecWeb.Vistas.Destinatarios.Destinatarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>HBS Energía</title>
  <%-- <%-- BTS4.6 --%>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <link href="../../Content/fontawesome-free-5.15.2-web/css/all.css" rel="stylesheet" />
    <link href="../../Content/DataTables/DataTables-1.10.23/css/jquery.dataTables.css" rel="stylesheet" />
    <link href="../../Content/Chart.css" rel="stylesheet" />    
    <link href="../../Content/bootstrap-select.css" rel="stylesheet" />
    
    <%-- JS --%>
    <script src="../../Scripts/jquery-3.6.4.js"></script>
    <script src="../../Scripts/moment.js"></script>
    <script src="../../Scripts/sweetalert2.all.min.js"></script>
    <script src="../../Scripts/bootstrap.bundle.js"></script>
    <script src="../../Scripts/popper.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>    
    <script src="../../Content/DataTables/DataTables-1.10.23/js/jquery.dataTables.js"></script>
    <script src="../../Scripts/Chart.js"></script> 
    <script src="../../Scripts/bootstrap-select.js"></script>
    
    <script src="../../Scripts/gijgo/modular/core.js"></script>
    <link href="../../Content/gijgo/modular/core.css" rel="stylesheet" />
    <link href="../../Content/gijgo/modular/datepicker.css" rel="stylesheet" />
    <link href="../../Content/gijgo/modular/timepicker.css" rel="stylesheet" />
    <link href="../../Content/gijgo/modular/datetimepicker.css" rel="stylesheet" />
    <script src="../../Scripts/gijgo/modular/datepicker.js"></script>
    <script src="../../Scripts/gijgo/modular/timepicker.js"></script>
    <script src="../../Scripts/gijgo/modular/datetimepicker.js"></script>
    
</head>
<body>

    <div class="col-12">

        <div class="row">
            <div class="col-1">
                <img src="../../Resources/nav_Logo.jpg" class="img-thumbnail" style="display: block; margin: auto;" />
            </div>
            <div class="col-11" style="background-image: url('../../Resources/navBar.jpg'); background-repeat: no-repeat; background-size: 2200px 150px;">
            </div>
        </div>

    </div>

    <nav class="navbar navbar-expand-lg bg-white">

        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                    <label></label>
                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                     <label></label>
                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    <button class="btn btn-outline-secondary btn-lg my-2 my-sm-0" type="button" id="lobby"><i class="fas fa-home">&nbsp&nbsp Home </i></button>
                    &nbsp&nbsp
                    <button class="btn btn-outline-secondary btn-lg my-2 my-sm-0" type="button" id="evento"><i class="fas fa-calendar-alt"></i>&nbsp&nbsp Eventos</button>&nbsp&nbsp 
                </li>
                <li class="nav-item"></li>
            </ul>
            <form class="form-inline my-2 my-lg-0">
                <button class="btn btn-outline-secondary btn-lg my-3 my-sm-0" type="button" id="destinatario" data-toggle="tooltip" data-placement="bottom" title="Destinatarios"><i class="fas fa-user"></i></button>&nbsp&nbsp 
                <button class="btn btn-outline-warning bg-warning text-secondary btn-lg my-2 my-sm-0" type="button" id="sesion"><i class="fas fa-sign-out-alt"></i>&nbsp&nbsp Cerrar sesión</button>
            </form>
        </div>
    </nav>

    <div class="py-5">
        <div class="container-fluid">
            <div class="col-md-4">
                <button type="button" class="btn btn-warning text-black" id="_newDest" data-toggle="modal" data-target="#newDestinatario"><i class="fas fa-plus"></i>&nbsp&nbsp REGISTRAR NUEVO DESTINATARIO</button>
            </div>
            <br />
            <div class="col-md-12">
                <table id="tblDestinatarios" class="table table-striped table-bordered" style="width: 100%">
                    <thead>
                        <tr>
                            <th></th>
                            <th>Email</th>
                            <th>Nombre</th>
                            <th>Zonas</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody id="bodEvents">
                    </tbody>

                </table>
            </div>
        </div>
    </div>

    <%-- MODALS REG --%>

    <div class="modal fade" id="newDestinatario" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title" id="">Registrar nuevo destinatario</h4>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <div class="py-2">
                        <div class="container-fluid">

                            <div class="row">
                                <div class="col-md-12">
                                    <form id="c_form-h" class="">
                                        <div class="form-group row">
                                            <label class="col-3 col-form-label"><strong>Correo</strong></label>
                                            <div class="col-6">
                                                <input type="text" class="form-control" id="correo" value="" />
                                            </div>
                                            <label id="msgCorreo" class="col-3 col-form-label text-danger"><strong></strong></label>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-3 col-form-label"><strong>Nombre</strong></label>
                                            <div class="col-6">
                                                <input type="text" class="form-control" id="nombre" value="" />
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-3 col-form-label"><strong>Apellido</strong></label>
                                            <div class="col-6">
                                                <input type="text" class="form-control" id="apellido" value="" />
                                            </div>
                                        </div>


                                    </form>
                                </div>

                            </div>

                        </div>
                    </div>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <button type="button" id="guardar" class="btn btn-success btn-lg">GUARDAR</button>
                    <button type="button" class="btn btn-danger btn-lg" data-dismiss="modal">Cerrar</button>
                </div>

            </div>
        </div>
    </div>


    <div class="modal fade" id="editDestinatario" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title" id="">Editar nuevo destinatario</h4>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <div class="py-2">
                        <div class="container-fluid">

                            <div class="row">
                                <div class="col-md-12">
                                    <form id="" class="">
                                        <div class="form-group row">
                                            <label class="col-3 col-form-label"><strong>Correo</strong></label>
                                            <div class="col-6">
                                                <input type="text" class="form-control" id="correoEdit" value="" />
                                            </div>
                                            <label id="msgCorreoEdit" class="col-3 col-form-label text-danger"><strong></strong></label>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-3 col-form-label"><strong>Nombre</strong></label>
                                            <div class="col-6">
                                                <input type="text" class="form-control" id="nombreEdit" value="" />
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-3 col-form-label"><strong>Apellido</strong></label>
                                            <div class="col-6">
                                                <input type="text" class="form-control" id="apellidoEdit" value="" />
                                            </div>
                                        </div>
                                        <hr />
                                        <div class="form-group row">
                                            <label class="col-3 col-form-label"><strong>Zona asignada</strong></label>
                                            <div class="col-6" id="">
                                                <select multiple class="selectpicker" data-width="100%" id="lstAsigMaqEdit" title="No se ha asignado zona al destinatario">
                                                </select>
                                            </div>

                                        </div>

                                    </form>
                                </div>

                            </div>

                        </div>
                    </div>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <button type="button" id="guardarEditar" class="btn btn-success btn-lg">GUARDAR</button>
                    <button type="button" class="btn btn-danger btn-lg" data-dismiss="modal">Cerrar</button>
                </div>

            </div>
        </div>
    </div>

    <input id="idDestinatarioEdit" type="hidden" value="" />
</body>

<script>
    $(document).ready(function () {

        $('#lstMaq').selectpicker();

        $('#tblDestinatarios').DataTable({
            "columns": [
                { "width": "3%" },
                { "width": "23%" },
                { "width": "30%" },
                { "width": "35%" },                
                { "width": "12%" }
            ],
            "lengthMenu": [[20], [20]],
            "pageLength": 20,
            "order": [[0, 'asc']],
            "language": {
                "sProcessing": " Procesando...",
                "sLengthMenu": " Mostrar _MENU_ registros",
                "sZeroRecords": " No se encontraron resultados",
                "sEmptyTable": " Ningún dato disponible en esta tabla",
                "sInfo": " Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": " Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": " (filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": " Buscar:",
                "sUrl": "",
                "sInfoThousands": ".",
                "sLoadingRecords": " Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior",
                    "oAria": {
                        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                    }
                }
            },
            "initComplete": () => { $("#tblAuditorias").show(); }
        }

        );

        const showLoading = function () {
            let timerInterval
            Swal.fire({
                title: 'Cargando información.',
                html: 'Buscando y desencriptando datos...',
                timer: 1500,
                timerProgressBar: true,
                showConfirmButton: false,
                allowOutsideClick: false,
                allowEscapeKey: false,
                onBeforeOpen: () => {
                    Swal.showLoading()
                    timerInterval = setInterval(() => {
                        const content = Swal.getContent()
                        if (content) {
                            const b = content.querySelector('b')
                            if (b) {
                                b.textContent = Swal.getTimerLeft()
                            }
                        }
                    }, 1500)
                },
                onClose: () => {
                    clearInterval(timerInterval)
                }
            }).then((result) => {
                /* Read more about handling dismissals below */
                if (result.dismiss === Swal.DismissReason.timer) {
                }
            })
        };


        function load() {
            showLoading();
            var jSonData = "{'key': 'key'}";
            $.ajax(
                {
                    url: "Destinatarios.aspx/load",
                    data: jSonData,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {
                        $("body").append(result.d);
                    },
                    error: function (xhr, status, error) {
                        alert("ERROR " + error.status + ' ' + error.statusText);
                    }
                });

        }


        $('#tblDestinatarios tbody').on('click', 'td button.details-Editar', function (e) {

            var tr = $(this).closest('button');
            keyDoc = tr.attr('name');
            var jSonData = "{'key': '" + keyDoc + "'}";
            $.ajax(
                {
                    url: "Destinatarios.aspx/LoadInfoEditar",
                    data: jSonData,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {
                        $("body").append(result.d);

                        $('#editDestinatario').show();
                        $('#editDestinatario').modal({ backdrop: 'static', keyboard: false });
                    },
                    error: function (xhr, status, error) {
                        alert("ERROR " + error.status + ' ' + error.statusText);
                    }
                });

        });

        $('#tblDestinatarios tbody').on('click', 'td button.details-Eliminar', function (e) {

            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'btn btn-success',
                    cancelButton: 'btn btn-danger'
                },
                buttonsStyling: true
            })

            swalWithBootstrapButtons.fire({
                title: '¿Desea eliminar el destinatario?',
                text: "Una vez eliminado no se puede revertir.",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: '    SI',
                cancelButtonText: 'NO    ',
                reverseButtons: true
            }).then((result) => {
                if (result.isConfirmed) {
                    swalWithBootstrapButtons.fire(
                        'Eliminado!',
                        'Destinatario eliminado con éxito',
                        'success'
                    )

                    var tr = $(this).closest('button');
                    keyDoc = tr.attr('name');
                    var jSonData = "{'key': '" + keyDoc + "'}";
                    $.ajax(
                        {
                            url: "Destinatarios.aspx/EliminarDestinatario",
                            data: jSonData,
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (result) {
                                $("body").append(result.d);
                            },
                            error: function (xhr, status, error) {
                                alert("ERROR " + error.status + ' ' + error.statusText);
                            }
                        });

                } else if (
                    /* Read more about handling dismissals below */
                    result.dismiss === Swal.DismissReason.cancel
                ) {
                    swalWithBootstrapButtons.fire(
                        'Cancelado',
                        'Se canceló la eliminación del evento',
                        'info'
                    )
                }
            });

            

        });



        $('#lobby').on('click', function () {

            redirectHome();

        });

        $('#evento').on('click', function () {

            redirectEventos();

        });

        $('#destinatario').on('click', function () {

            redirectDestinatarios();

        });

        $('#sesion').on('click', function () {

            redirectSesion();

        });

        $('#guardar').on('click', function () {

            GuardarDestinatario();

        });

        $('#guardarEditar').on('click', function () {

            SaveEventEdit();

        });

        $('#_newDest').on('click', function () {

            var jSonData = "{'u': 'u'}";
            $.ajax(
                {
                    url: "Destinatarios.aspx/Reset",
                    data: jSonData,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {

                        $("body").append(result.d);
                    },
                    error: function (xhr, status, error) {
                        alert("ERROR " + error.status + ' ' + error.statusText);
                    }
                });

        });
       
        
        function redirectHome() {
            var jSonData = "{'u': 'u'}";
            $.ajax(
                {
                    url: "Destinatarios.aspx/redirectHome",
                    data: jSonData,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {

                        $("body").append(result.d);
                    },
                    error: function (xhr, status, error) {
                        alert("ERROR " + error.status + ' ' + error.statusText);
                    }
                });

        }


        function redirectSesion() {
            var jSonData = "{'u': 'u'}";
            $.ajax(
                {
                    url: "Destinatarios.aspx/redirectSesion",
                    data: jSonData,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {

                        $("body").append(result.d);
                    },
                    error: function (xhr, status, error) {
                        alert("ERROR " + error.status + ' ' + error.statusText);
                    }
                });
        }

        function redirectEventos() {
            var jSonData = "{'u': 'u'}";
            $.ajax(
                {
                    url: "Destinatarios.aspx/redirectEventos",
                    data: jSonData,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {

                        $("body").append(result.d);
                    },
                    error: function (xhr, status, error) {
                        alert("ERROR " + error.status + ' ' + error.statusText);
                    }
                });

        }

        function redirectDestinatarios() {
            var jSonData = "{'u': 'u'}";
            $.ajax(
                {
                    url: "Destinatarios.aspx/redirectDestinatarios",
                    data: jSonData,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {

                        $("body").append(result.d);
                    },
                    error: function (xhr, status, error) {
                        alert("ERROR " + error.status + ' ' + error.statusText);
                    }
                });

        }

        function GuardarDestinatario() {
            var jSonData = "{'cor':'" + $('#correo').val() + "', 'nom': '" + $('#nombre').val() + "', 'ape': '" + $('#apellido').val() + "'}";
            $.ajax(
                {
                    url: "Destinatarios.aspx/GuardarDestinatario",
                    data: jSonData,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {

                        $("body").append(result.d);
                        $('#newDestinatario').show();
                        $('#newDestinatario').modal({ backdrop: 'static', keyboard: false });
                    },
                    error: function (xhr, status, error) {
                        alert("ERROR " + error.status + ' ' + error.statusText);
                    }
                });

        }

        function SaveEventEdit() {
            var jSonData = "{'idD':'" + $('#idDestinatarioEdit').val() + "', 'cor':'" + $('#correoEdit').val() + "', 'nom': '" + $('#nombreEdit').val() + "', 'ape': '" + $('#apellidoEdit').val() + "', 'mq': '" + $('#lstAsigMaqEdit').val() + "'}";
            $.ajax(
                {
                    url: "Destinatarios.aspx/GuardarDestinatarioEdit",
                    data: jSonData,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {

                        $("body").append(result.d);
                    },
                    error: function (xhr, status, error) {
                        alert("ERROR " + error.status + ' ' + error.statusText);
                    }
                });

        }

        $('#sesion').on('click', function () {
            var jSonData = "{'key': 'key'}";
            $.ajax(
                {
                    url: "Eventos.aspx/logOut",
                    data: jSonData,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {
                        $("body").append(result.d);
                    },
                    error: function (xhr, status, error) {
                        alert("ERROR " + error.status + ' ' + error.statusText);
                    }
                });

        });

        load();

        $('option').mousedown(function (e) {
            e.preventDefault();
            $(this).prop('selected', !$(this).prop('selected'));
            return false;
        });

    });
</script>


</html>
