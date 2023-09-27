<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="LisalecWeb.Vistas.Dashboard.Dashboard" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>HBS Energía</title>
   <%-- BTS4.6 --%>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <link href="../../Content/fontawesome-free-5.15.2-web/css/all.css" rel="stylesheet" />
    <link href="../../Content/DataTables/DataTables-1.10.23/css/jquery.dataTables.css" rel="stylesheet" />
    <link href="../../Content/Chart.css" rel="stylesheet" />    
    <link href="../../Content/bootstrap-select.css" rel="stylesheet" />
    <link href="../../Content/hbs_style.css" rel="stylesheet" />
    
    <%-- JS --%>
    <script src="../../Scripts/jquery-3.5.1.js"></script>
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
                <img src="../../Resources/nav_Logo.jpg" class="img-thumbnail" style=" display:block; margin:auto;"  />
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



    <div class="">
        <div class="row">
            <div class="col-12">
                <hr class="outline-secondary btn-lg my-2 my-sm-0" />
                <div class="col-12">
                    <button class="btn btn-outline-secondary btn-lg my-2 my-sm-0" type="button" id="evento2">Quillota</button>&nbsp&nbsp 
                <button class="btn btn-outline-secondary btn-lg my-2 my-sm-0" type="button" id="evento1" disabled>Los Angeles</button>&nbsp&nbsp 
                </div>
            </div>
        </div>
        <hr />
        <div class="col-xl-12">
            <div class="row">
                <div class="col-lg-1" style="">
                    <div class="card" style="height: 708px;">
                        <div class="card-body">
                            <strong>
                                <h5 class="card-title " id="" disabled style="writing-mode: vertical-rl; text-orientation: upright;">Tomaval Generación</h5>
                            </strong>
                        </div>
                    </div>
                </div>
                <div class="col-lg-11" style="">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card ">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-2">
                                            <strong>
                                                <h5 class="card-title" id="nomMaq1" style="">TMVG - TBG/M4</h5>
                                            </strong>
                                            <a href="#" class="card-link" data-toggle="modal" data-target="#detMaquina1">Más detalles</a>
                                        </div>
                                        <div class="col-md-2">
                                            <label>Active Power </label>
                                            <input type="text" id="actPower1" disabled /><label>&nbsp&nbsp kW </label>
                                        </div>
                                        <div class="col-md-2">
                                            <label>Act. Power Req</label>
                                            <input type="text" id="actPpowerReq1" disabled /><label>&nbsp&nbsp kW </label>
                                            <hr />
                                            <label>Nominal Power</label>
                                            <input type="text" id="norminPower1" disabled /><label>&nbsp&nbsp kW </label>
                                        </div>
                                        <div class="col-md-2">
                                            <label>Engine State</label>
                                            <h5><span id="engineState" class="badge-pill"></span>&nbsp&nbsp&nbsp<label id="engineStateLabel1" class="infoestado"></label></h5>
                                            <hr />
                                            <label>Unit State</label>
                                            <h5><span id="unitState" class="badge-pill "></span>&nbsp&nbsp&nbsp<label id="unitStateLabel1" class="infoestado"></label></h5>
                                        </div>
                                        <div class="col-md-2">
                                            <label> kWh (Import)</label>
                                            <input type="text" id="Kwh1" disabled /><label>&nbsp&nbsp kWh </label>
                                            <hr />
                                            <label>Run hours &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</label>
                                            <input type="text" id="runHours1" disabled /><label>&nbsp  </label>
                                        </div>
                                        <div class="col-md-2">
                                            <label>Last Update &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</label>
                                            <input type="text" id="lastUpdate1" disabled /><label>&nbsp  </label>
                                            <hr />
                                            <label>Comunication Status</label>
                                            <h5><span id="comState" class="badge-pill "></span>&nbsp&nbsp&nbsp<label id="comStateLabel1" class="infoestado"></label></h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card ">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-2">
                                            <strong>
                                                <h5 class="card-title" id="nomMaq2" style="">BCG - M5</h5>
                                            </strong>
                                            <a href="#" class="card-link" data-toggle="modal" data-target="#detMaquina3">Más detalles</a>
                                        </div>
                                        <div class="col-md-2">
                                            <label>Active Power </label>
                                            <input type="text" id="actPower2" disabled /><label>&nbsp&nbsp kW </label>
                                        </div>
                                        <div class="col-md-2">
                                            <label>Act. Power Req</label>
                                            <input type="text" id="actPpowerReq2" disabled /><label>&nbsp&nbsp kW </label>
                                            <hr />
                                            <label>Nominal Power</label>
                                            <input type="text" id="norminPower2" disabled /><label>&nbsp&nbsp kW </label>
                                        </div>
                                        <div class="col-md-2">
                                            <label>Engine State</label>
                                            <h5><span id="engineState2" class="badge-pill"></span>&nbsp&nbsp&nbsp<label id="engineState2Label1" class="infoestado"></label></h5>
                                            <hr />
                                            <label>Unit State</label>
                                            <h5><span id="unitState2" class="badge-pill "></span>&nbsp&nbsp&nbsp<label id="unitState2Label1" class="infoestado"></label></h5>
                                        </div>
                                        <div class="col-md-2">
                                            <label>kWh (Import)</label>
                                            <input type="text" id="Kwh2" disabled /><label>&nbsp&nbsp kWh </label>
                                            <hr />
                                            <label>Run hours &nbsp&nbsp&nbsp</label>
                                            <input type="text" id="runHours2" disabled /><label>&nbsp  </label>
                                        </div>
                                        <div class="col-md-2">
                                            <label>Last Update &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</label>
                                            <input type="text" id="lastUpdate2" disabled /><label>&nbsp  </label>
                                            <hr />
                                            <label>Comunication Status</label>
                                            <h5><span id="comState2" class="badge-pill "></span>&nbsp&nbsp&nbsp<label id="comState2Label1" class="infoestado"></label></h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-2">
                                            <strong>
                                                <h5 class="card-title" id="nomMaq3" style="">BCG - M3</h5>
                                            </strong>
                                            <a href="#" class="card-link" data-toggle="modal" data-target="#detMaquina4">Más detalles</a>
                                        </div>
                                        <div class="col-md-2">
                                            <label>Active Power </label>
                                            <input type="text" id="actPower3" disabled /><label>&nbsp&nbsp kW </label>
                                        </div>
                                        <div class="col-md-2">
                                            <label>Act. Power Req</label>
                                            <input type="text" id="actPpowerReq3" disabled /><label>&nbsp&nbsp kW </label>
                                            <hr />
                                            <label>Nominal Power</label>
                                            <input type="text" id="norminPower3" disabled /><label>&nbsp&nbsp kW </label>
                                        </div>
                                        <div class="col-md-2">
                                            <label>Engine State</label>
                                            <h5><span id="engineState3" class="badge-pill"></span>&nbsp&nbsp&nbsp<label id="engineState3Label1" class="infoestado"></label></h5>
                                            <hr />
                                            <label>Unit State</label>
                                            <h5><span id="unitState3" class="badge-pill "></span>&nbsp&nbsp&nbsp<label id="unitState3Label1" class="infoestado"></label></h5>

                                        </div>
                                        <div class="col-md-2">
                                            <label>kWh (Import)</label>
                                            <input type="text" id="Kwh3" disabled /><label>&nbsp&nbsp kWh </label>
                                            <hr />
                                            <label>Run hours &nbsp&nbsp&nbsp&nbsp</label>
                                            <input type="text" id="runHours3" disabled /><label>&nbsp  </label>
                                        </div>
                                        <div class="col-md-2">
                                            <label>Last Update  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</label>
                                            <input type="text" id="lastUpdate3" disabled /><label>&nbsp  </label>
                                            <hr />
                                            <label>Comunication Status</label>
                                            <h5><span id="comState3" class="badge-pill "></span>&nbsp&nbsp&nbsp<label id="comState3Label1" class="infoestado"></label></h5>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                </div>
            </div>
        </div>

      
    </div>




   


    <div class="modal fade" id="detMaquina1" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <strong>
                        <h4 class="modal-title" id="nomMaq1Modal"></h4>
                    </strong>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-4" style="">
                                <div class="row">
                                    <div class="col-md-12" style="">
                                        <div class="card">

                                            <div class="card-body">
                                                <form class="">
                                                    <div class="form-group">
                                                        <label>Potencia nominal</label>
                                                        <input disabled class="form-control" id="pn1Modal">
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Potencia Real</label>
                                                        <input disabled class="form-control" id="pr1Modal">
                                                    </div>
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8" style="">
                                <canvas id="myChart" width="600" height="250"></canvas>

                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-12">
                                <table id="tblMaq1" class="table table-striped table-bordered" style="width: 100%">
                                    <thead>
                                        <tr>
                                            <th></th>
                                            <th>Fecha | Hora </th>
                                            <th>Evento</th>
                                            <th>Descripción</th>
                                        </tr>
                                    </thead>
                                    <tbody id="bodEvents">
                                    </tbody>

                                </table>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger btn-lg" data-dismiss="modal">Cerrar</button>
                </div>

            </div>
        </div>
    </div>

    <div class="modal fade" id="detMaquina3" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <strong>
                        <h4 class="modal-title" id="nomMaq3Modal"></h4>
                    </strong>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-4" style="">
                                <div class="row">
                                    <div class="col-md-12" style="">
                                        <div class="card">

                                            <div class="card-body">
                                                <form class="">
                                                    <div class="form-group">
                                                        <label>Potencia nominal</label>
                                                        <input disabled class="form-control" id="pn3Modal">
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Potencia Real</label>
                                                        <input disabled class="form-control" id="pr3Modal">
                                                    </div>
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8" style="">
                                <canvas id="myChart3" width="600" height="250"></canvas>

                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-12">
                                <table id="tblMaq3" class="table table-striped table-bordered" style="width: 100%">
                                    <thead>
                                        <tr>
                                            <th></th>
                                            <th>Fecha | Hora </th>
                                            <th>Evento</th>
                                            <th>Descripción</th>
                                        </tr>
                                    </thead>
                                    <tbody id="bodEvent3">
                                    </tbody>

                                </table>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger btn-lg" data-dismiss="modal">Cerrar</button>
                </div>

            </div>
        </div>
    </div>

    <div class="modal fade" id="detMaquina4" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <strong>
                        <h4 class="modal-title" id="nomMaq4Modal"></h4>
                    </strong>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-4" style="">
                                <div class="row">
                                    <div class="col-md-12" style="">
                                        <div class="card">

                                            <div class="card-body">
                                                <form class="">
                                                    <div class="form-group">
                                                        <label>Potencia nominal</label>
                                                        <input disabled class="form-control" id="pn4Modal">
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Potencia Real</label>
                                                        <input disabled class="form-control" id="pr4Modal">
                                                    </div>
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8" style="">
                                <canvas id="myChart4" width="600" height="250"></canvas>

                            </div>
                        </div>
                        <hr>
                        <div class="row">
                            <div class="col-md-12">
                                <table id="tblMaq4" class="table table-striped table-bordered" style="width: 100%">
                                    <thead>
                                        <tr>
                                            <th></th>
                                            <th>Fecha | Hora </th>
                                            <th>Evento</th>
                                            <th>Descripción</th>
                                        </tr>
                                    </thead>
                                    <tbody id="bodEvent4">
                                    </tbody>

                                </table>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger btn-lg" data-dismiss="modal">Cerrar</button>
                </div>

            </div>
        </div>
    </div>


</body>

     <script>
         $(document).ready(function () {

             $('#tblMaq1').DataTable({
                 "columns": [
                     { "width": "2%" },
                     { "width": "20%" },
                     { "width": "20%" },
                     { "width": "55%" }
                 ],
                 "lengthMenu": [[10], [10]],
                 "pageLength": 10,
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
                 "initComplete": () => { $("#tblMaq1").show(); }
             }

             );
             $('#tblMaq3').DataTable({
                 "columns": [
                     { "width": "2%" },
                     { "width": "20%" },
                     { "width": "20%" },
                     { "width": "55%" }
                 ],
                 "lengthMenu": [[10], [10]],
                 "pageLength": 10,
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
                 "initComplete": () => { $("#tblMaq1").show(); }
             }

             );
             $('#tblMaq4').DataTable({
                 "columns": [
                     { "width": "2%" },
                     { "width": "20%" },
                     { "width": "20%" },
                     { "width": "55%" }
                 ],
                 "lengthMenu": [[10], [10]],
                 "pageLength": 10,
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
                 "initComplete": () => { $("#tblMaq1").show(); }
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

             $('#lobby').on('click', function () {

                 redirectHome();
             });

             $('#evento').on('click', function () {

                 redirectEventos();
             });

             $('#destinatario').on('click', function () {

                 redirectDestinatarios();
             });



             function redirectHome() {
                 var jSonData = "{'u': 'u'}";
                 $.ajax(
                     {
                         url: "Dashboard.aspx/redirectHome",
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
                         url: "Dashboard.aspx/logOut",
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


             function redirectSesion() {
                 var jSonData = "{'u': 'u'}";
                 $.ajax(
                     {
                         url: "Dashboard.aspx/redirectSesion",
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
                         url: "Dashboard.aspx/redirectEventos",
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
                         url: "Dashboard.aspx/redirectDestinatarios",
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


             function load() {
                 showLoading();
                 var jSonData = "{'key': 'key'}";
                 $.ajax(
                     {
                         url: "Dashboard.aspx/load",
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
             function load_3() {
                 showLoading();
                 var jSonData = "{'key': 'key'}";
                 $.ajax(
                     {
                         url: "Dashboard.aspx/load_3",
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

             function load_4() {
                 showLoading();
                 var jSonData = "{'key': 'key'}";
                 $.ajax(
                     {
                         url: "Dashboard.aspx/load_4",
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

             load();
             load_3();
             load_4();

         });
     </script>


</html>
