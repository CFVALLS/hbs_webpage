<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Eventos.aspx.cs" Inherits="LisalecWeb.Vistas.Eventos.Eventos" %>


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
    <link href="../../Content/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    

    <%-- JS --%>
    <script src="../../Scripts/jquery-3.6.4.js"></script>
    <script src="../../Scripts/moment.js"></script>
    <script src="../../Scripts/moment-with-locales.js"></script>
    <script src="../../Scripts/moment-timezone-with-data.js"></script>
    <script src="../../Scripts/sweetalert2.all.min.js"></script>
    <script src="../../Scripts/bootstrap.bundle.js"></script>
    <script src="../../Scripts/popper.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>    
    <script src="../../Content/DataTables/DataTables-1.10.23/js/jquery.dataTables.js"></script>
    <script src="../../Scripts/Chart.js"></script> 
    <script src="../../Scripts/bootstrap-select.js"></script>
    <script src="../../Scripts/bootstrap-datetimepicker.js"></script>
    <link href="../../Content/font-awesome.min.css" rel="stylesheet" />
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
       
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation" >
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                     <label></label> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                     <label></label> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    <button class="btn btn-outline-secondary btn-lg my-2 my-sm-0" type="button" id="lobby"><i class="fas fa-home">&nbsp&nbsp Home </i></button> &nbsp&nbsp
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
                <button type="button" class="btn btn-warning text-black" id="_newEvent" data-toggle="modal" data-target="#newEvent"><i class="fas fa-plus"></i>&nbsp&nbsp REGISTRAR NUEVO EVENTO</button>
            </div>
            <br />
            <div class="col-md-12">
                <table id="tblEventos" class="table table-striped table-bordered" style="width: 100%">
                    <thead>
                        <tr>
                            <th></th>
                            <th>Fecha | Hora </th>
                            <th>ID Unidad Generadora</th>
                            <th>Descripción</th>
                            <th>Tipo evento</th>
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

    <div class="modal fade" id="newEvent">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title" id="">Registrar nuevo evento</h4>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <div class="py-2">
                        <div class="container-fluid">

                            <div class="row">
                                <div class="col-md-12">
                                    <form id="c_form-h" class="">
                                        <div class="form-group row">
                                            <label class="col-3 col-form-label"><strong>Fecha</strong></label>                                            
                                            <div class="col-md-3">
                                                <div> <input type='text' id="fechaActual" disabled class="form-control" /></div>
                                            </div>
                                            <div class="col-2"  >
                                                <input type="time" class="form-control" id="hora" value="" />
                                            </div>
                                           
                                        </div>

                                        <div class="form-group row">
                                            <label class="col-3 col-form-label"><strong>Unidad Generadora</strong></label>
                                            <div class="col-3">
                                                <select class="selectpicker show-tick" id="lstMaq">
                                                </select>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-3 col-form-label"><strong>Tipo</strong></label>
                                            <div class="col-3">
                                                <select class="selectpicker show-tick" id="lstTipo">
                                                </select>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-3 col-form-label"><strong>Usuario</strong></label>
                                            <div class="col-3">
                                                <input type="text" class="form-control" id="codUsuario" value="" />
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-3 col-form-label"><strong>Detalle evento</strong></label>
                                            <div class="col-9">
                                                <textarea class="form-control" id="detalle" rows="10"></textarea>
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


    <div class="modal fade" id="editEvent">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title" id="">Editar evento</h4>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <div class="py-2">
                        <div class="container-fluid">

                            <div class="row">
                                <div class="col-md-12">
                                    <form id="c_form-h_" class="">
                                        <div class="form-group row">                                            
                                           <label class="col-3 col-form-label"><strong>Fecha</strong></label>                                            
                                            <div class="col-md-3">
                                                <div> <input type='text' id="fechaActualEdit" disabled class="form-control" /></div>
                                            </div>
                                            <div class="col-2"  >
                                                <input type="time" class="form-control" id="horaEdit" value="" />
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <label class="col-3 col-form-label"><strong>Unidad Generadora</strong></label>
                                            <div class="col-3">
                                                <select class="selectpicker show-tick" id="lstMaqEdit">
                                                </select>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-3 col-form-label"><strong>Tipo</strong></label>
                                            <div class="col-3">
                                                <select class="selectpicker show-tick" id="lstTipoEdit">
                                                </select>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-3 col-form-label"><strong>Usuario</strong></label>
                                            <div class="col-3">
                                                <input type="text" class="form-control" id="codUsuarioEdit" value="" />
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-3 col-form-label"><strong>Detalle evento</strong></label>
                                            <div class="col-9">
                                                <textarea class="form-control" id="detalleEdit" rows="10"></textarea>
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
                    <button type="button" id="guardarEditar" class="btn btn-success btn-lg">EDITAR</button>
                    <button type="button" class="btn btn-danger btn-lg" data-dismiss="modal">Cerrar</button>
                </div>

            </div>
        </div>
    </div>

    <input id="idEventEdit" type="hidden" value="" />
</body>

<script>
    $(document).ready(function () {
        
       /*
        $('#fechaActual').datetimepicker({
            locale: 'es',
            inline: true,
            sideBySide: true,
            format: 'LT'
        });

        $('#fechaActualEdit').datetimepicker({
            locale: 'es',
            inline: true,
            sideBySide: true,
            format: 'LT'
        });
        */

        $('#lstMaq').selectpicker();
        $('#lstTipo').selectpicker();

        $('#tblEventos').DataTable({
            "columns": [
                { "width": "3%" },
                { "width": "14%" },
                { "width": "20%" },
                { "width": "39%" },
                { "width": "12%" },
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
                    url: "Eventos.aspx/load",
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


        $('#tblEventos tbody').on('click', 'td button.details-Editar', function (e) {

            var tr = $(this).closest('button');
            keyDoc = tr.attr('name');
            var jSonData = "{'key': '" + keyDoc + "'}";
            $.ajax(
                {
                    url: "Eventos.aspx/LoadInfoEditar",
                    data: jSonData,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {
                        $("body").append(result.d);

                        $('#editEvent').show();
                        $('#editEvent').modal({ backdrop: 'static', keyboard: false });
                    },
                    error: function (xhr, status, error) {
                        alert("ERROR " + error.status + ' ' + error.statusText);
                    }
                });

        });

        $('#tblEventos tbody').on('click', 'td button.details-Eliminar', function (e) {

            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'btn btn-success',
                    cancelButton: 'btn btn-danger'
                },
                buttonsStyling: true
            })

            swalWithBootstrapButtons.fire({
                title: '¿Desea eliminar el evento?',
                text: "Una vez eliminado no se puede revertir.",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'SI',
                cancelButtonText: 'NO',
                reverseButtons: true
            }).then((result) => {
                if (result.isConfirmed) {
                    swalWithBootstrapButtons.fire(
                        'Eliminado!',
                        'Evento eliminado con éxito',
                        'success'
                    )

                    var tr = $(this).closest('button');
                    keyDoc = tr.attr('name');
                    var jSonData = "{'key': '" + keyDoc + "'}";
                    $.ajax(
                        {
                            url: "Eventos.aspx/EliminarEvento",
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

            SaveEvent();

        });

        $('#guardarEditar').on('click', function () {

            SaveEventEdit();

        });

        $('#_newEvent').on('click', function () {

            var jSonData = "{'u': 'u'}";
            $.ajax(
                {
                    url: "Eventos.aspx/Reset",
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

        function redirectDestinatarios() {
            var jSonData = "{'u': 'u'}";
            $.ajax(
                {
                    url: "Eventos.aspx/redirectDestinatarios",
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

        function redirectHome() {
            var jSonData = "{'u': 'u'}";
            $.ajax(
                {
                    url: "Eventos.aspx/redirectHome",
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
                    url: "Eventos.aspx/redirectSesion",
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
                    url: "Eventos.aspx/redirectEventos",
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
               

        function SaveEvent() {
            var jSonData = "{'det':'" + $('#detalle').val() + "', 'idMaq': '" + $('#lstMaq').val() + "', 'idEv': '" + $('#lstTipo').val() + "', 'fecha': '" + $('#fechaActual').val() + "', 'usu': '" + $('#codUsuario').val() + "', 'hora': '" + $('#hora').val() + "'}";
            $.ajax(
                {
                    url: "Eventos.aspx/SaveEvent",
                    data: jSonData,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {
                        $('#newEvent').modal({ backdrop: 'static', keyboard: false })
                        $("body").append(result.d);
                    },
                    error: function (xhr, status, error) {
                        alert("ERROR " + error.status + ' ' + error.statusText);
                    }
                });

        }

        function SaveEventEdit() {
            var jSonData = "{'idE':'" + $('#idEventEdit').val() + "', 'det':'" + $('#detalleEdit').val() + "', 'idMaq': '" + $('#lstMaqEdit').val() + "', 'idEv': '" + $('#lstTipoEdit').val() + "','fecha': '" + $('#fechaActualEdit').val() + "','usu': '" + $('#codUsuarioEdit').val() + "', 'hora': '" + $('#horaEdit').val() + "'}";
            $.ajax(
                {
                    url: "Eventos.aspx/SaveEventEdit",
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


    });
</script>


</html>
