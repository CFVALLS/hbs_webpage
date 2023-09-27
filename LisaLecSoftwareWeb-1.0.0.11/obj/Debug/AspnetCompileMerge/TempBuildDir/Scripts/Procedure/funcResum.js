$(document).ready(function () {

/****** LOAD   *****/

    $('select').selectpicker();
    $('#dtCum').datepicker({ uiLibrary: 'bootstrap4', iconsLibrary: 'fontawesome', size: 'large', locale: 'es-es', format: 'dd/mm/yyyy'});
    $('#dtFReg').datepicker({ uiLibrary: 'bootstrap4', iconsLibrary: 'fontawesome', size: 'large', locale: 'es-es', format: 'dd/mm/yyyy' });
    $('#dtDesde').datepicker({ uiLibrary: 'bootstrap4', iconsLibrary: 'fontawesome', size: 'large', locale: 'es-es', format: 'dd/mm/yyyy' });
    $('#dtHasta').datepicker({ uiLibrary: 'bootstrap4', iconsLibrary: 'fontawesome', size: 'large', locale: 'es-es', format: 'dd/mm/yyyy' });
    $('#dtCom').datepicker({ uiLibrary: 'bootstrap4', iconsLibrary: 'fontawesome', size: 'large', locale: 'es-es', format: 'dd/mm/yyyy' });
    $('#dtComHasta').datepicker({ uiLibrary: 'bootstrap4', iconsLibrary: 'fontawesome', size: 'large', locale: 'es-es', format: 'dd/mm/yyyy' });

    const showLoading = function () {
        let timerInterval
        Swal.fire({
            title: 'Cargando información.',
            html: 'Buscando y desencriptando datos...',
            timer: 12000,
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
                }, 12000)
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

    $('#tblInternas').DataTable({
        "columns": [
            { "width": "4%" }, null, null, null, null, null, { "width": "3%" }, { "width": "5%" }, { "width": "10%" }, null, { "width": "20%" }, { "width": "15%" }
            , { "width": "10%" }, null, { "width": "10%" }, null, { "width": "3%" },null, { "width": "5%" }, null, null, null, null, null, { "width": "10%" }, null
        ],
        "fixedColumns": true,
        "paging": false,
        "autoWidth": false,
        "ordering": false,
        "lengthMenu": [["100000"], ["Todos"]],
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
        "initComplete": () => { $("#tblInternas").show(); },
        dom: 'Bfrtip',
        buttons: [{
            //Botón para Excel
            extend: 'excel',
            footer: false,
            title: 'Archivo',
            filename: 'Export_File',
            //Aquí es donde generas el botón personalizado
            text: '<button class="btn btn-lg btn-success"><i class="fas fa-file-excel"></i>&nbsp&nbsp Exportar a Excel</button>'
        }
        ]
    }

    );

    $('#tblExternas').DataTable({
        "columns": [
            { "width": "4%" }, null, null, null, null, null, { "width": "3%" }, { "width": "5%" }, { "width": "10%" }, null, { "width": "20%" }, { "width": "15%" }
            , { "width": "10%" }, null, { "width": "10%" }, null, { "width": "3%" }, null, { "width": "5%" }, null, null, null, null, null, { "width": "10%" }, null
        ],
        "fixedColumns": true,
        "ordering": false,
        "paging": false,
        "autoWidth": false,
        "lengthMenu": [["100000"], ["Todos"]],
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
        "initComplete": () => { $("#tblExternas").show(); },
        dom: 'Bfrtip',
        buttons: [{
            //Botón para Excel
            extend: 'excel',
            footer: false,
            title: 'Archivo',
            filename: 'Export_File',
            //Aquí es donde generas el botón personalizado
            text: '<button class="btn btn-lg btn-success"><i class="fas fa-file-excel"></i>&nbsp&nbsp Exportar a Excel</button>'
        }
        ]
    }

    );

    $('#tblCMF').DataTable({
        "columns": [
            { "width": "4%" }, null, null, null, null, null, { "width": "3%" }, { "width": "5%" }, { "width": "10%" }, null, { "width": "20%" }, { "width": "15%" }
            , { "width": "10%" }, null, { "width": "10%" }, null, { "width": "3%" },null, { "width": "5%" }, null, null, null, null, null, { "width": "10%" }, null
        ],
        "fixedColumns": true,
        "ordering": false,
        "paging": false,
        "autoWidth": false,
        "lengthMenu": [["100000"], ["Todos"]],
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
        "initComplete": () => { $("#tblCMF").show(); },
        dom: 'Bfrtip',
        buttons: [{
            //Botón para Excel
            extend: 'excel',
            footer: false,
            title: 'Archivo',
            filename: 'Export_File',
            //Aquí es donde generas el botón personalizado
            text: '<button class="btn btn-lg btn-success"><i class="fas fa-file-excel"></i>&nbsp&nbsp Exportar a Excel</button>'
        }
        ]
    }

    );

    reloadTabla();

    $('#inicio').on('click', function () {
        $('.selectpicker').html('').selectpicker('refresh');
        redirectInicio();
    });

    $('#informes').on('click', function () {
        $('.selectpicker').html('').selectpicker('refresh');
        reloadTabla();
    });

    function reloadTabla() {
            showLoading();
                var jSonData = "{'key': ''}";
                $.ajax(
                    {
                        url: "resumen.aspx/load",
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

    function redirectInicio() {
        var jSonData = "{'id_tabla': 'tblAuditorias'}";
        $.ajax(
            {
                url: "resumen.aspx/redirectInicio",
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

    $('#buscar').on('click', function () {
        showLoading();
        var jSonData = "{'des': '" + $("#dtDesde").val() + "' ,'has': '" + $("#dtHasta").val() + "',"+
            " 'cal':'" + $("#cboCali").val() + "', 'inCal':'" + $("#cboCali").prop('selectedIndex') + "'," +
            " 'tip':'" + $("#cboTipo").val() + "', 'inTip':'" + $("#cboTipo").prop('selectedIndex') + "'," +
            " 'sub':'" + $("#cboSubtipo").val() + "', 'inSub':'" + $("#cboSubtipo").prop('selectedIndex') + "'," +
            " 'are':'" + $("#cboArea").val() + "', 'inAre':'" + $("#cboArea").prop('selectedIndex') + "',"+
            " 'com': '" + $("#dtCom").val() + "', 'aud': '" + $("#txtAudit").val() + "'," +
            " 'apla':'" + $("#cboApla").val() + "', 'inApla':'" + $("#cboApla").prop('selectedIndex') + "'," +
            " 'est':'" + $("#cboEst_s").val() + "', 'inEst':'" + $("#cboEst_s").prop('selectedIndex') + "'," +
            " 'res':'" + $("#cboSolu").val() + "', 'inRes':'" + $("#cboSolu").prop('selectedIndex') + "'," +
            " 'resp':'" + $("#cboResp").val() + "', 'inResp':'" + $("#cboResp").prop('selectedIndex') + "'," +
            " 'comHas':'" + $("#dtComHasta").val() + "'" +
            "}";
        
        $.ajax(
            {
                url: "resumen.aspx/search",
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


    //**** INFO ***//

    $('#tblInternas tbody').on('click', 'td button.details-info', function (e) {

        var tr = $(this).closest('button');
        keyDoc = tr.attr('name');
        var jSonData = "{'key': '" + keyDoc + "'}";
        $.ajax(
            {
                url: "resumen.aspx/loadVerInfoAudit",
                data: jSonData,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    $("body").append(result.d);

                    $('#modalInfo').show();
                    $('#modalInfo').modal({ backdrop: 'static', keyboard: false });
                },
                error: function (xhr, status, error) {
                    alert("ERROR " + error.status + ' ' + error.statusText);
                }
            });

    });

    $('#tblInternas tbody').on('click', 'td button.details-ObsMas', function (e) {

            var tr = $(this).closest('button');
            keyDoc = tr.attr('name');
            var jSonData = "{'key': '" + keyDoc + "'}";
            $.ajax(
                {
                    url: "resumen.aspx/detObs",
                    data: jSonData,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {
                        $("body").append(result.d);

                        //$('#modalInfo').show();
                        //$('#modalInfo').modal({ backdrop: 'static', keyboard: false });
                    },
                    error: function (xhr, status, error) {
                        alert("ERROR " + error.status + ' ' + error.statusText);
                    }
                });

    });

    $('#tblInternas tbody').on('click', 'td button.details-ResMas', function (e) {

        var tr = $(this).closest('button');
        keyDoc = tr.attr('name');
        var jSonData = "{'key': '" + keyDoc + "'}";
        $.ajax(
            {
                url: "resumen.aspx/ResObs",
                data: jSonData,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    $("body").append(result.d);

                    //$('#modalInfo').show();
                    //$('#modalInfo').modal({ backdrop: 'static', keyboard: false });
                },
                error: function (xhr, status, error) {
                    alert("ERROR " + error.status + ' ' + error.statusText);
                }
            });

    });   

    $('#tblInternas tbody').on('click', 'td button.details-Obs', function (e) {

        var tr = $(this).closest('button');
        keyDoc = tr.attr('name');
        var jSonData = "{'key': '" + keyDoc + "'}";
        $.ajax(
            {
                url: "resumen.aspx/detObs",
                data: jSonData,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    $("body").append(result.d);

                    //$('#modalInfo').show();
                    //$('#modalInfo').modal({ backdrop: 'static', keyboard: false });
                },
                error: function (xhr, status, error) {
                    alert("ERROR " + error.status + ' ' + error.statusText);
                }
            });

    });  

    $('#tblInternas tbody').on('click', 'td button.details-SegNew', function (e) {
        //$('.selectpicker').html('').selectpicker('refresh');
        var tr = $(this).closest('button');
        keyDoc = tr.attr('name');
        var jSonData = "{'key': '" + keyDoc + "'}";
        $.ajax(
            {
                url: "resumen.aspx/loadSegNew",
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

    $('#tblInternas tbody').on('click', 'td button.details-SegCorreo', function (e) {
        //$('.selectpicker').html('').selectpicker('refresh');
        $('#txtDetEmail').html('');
        $('#emailUsuario').html('');
        var tr = $(this).closest('button');
        keyDoc = tr.attr('name');
        var jSonData = "{'key': '" + keyDoc + "'}";
        $.ajax(
            {
                url: "resumen.aspx/SegCorreo",
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

    $('#tblInternas tbody').on('click', 'td button.details-pdf', function (e) {
        var tr = $(this).closest('button');
        keyDoc = tr.attr('name');
        var jSonData = "{'key': '" + keyDoc + "'}";
        $.ajax(
            {
                url: "resumen.aspx/downloadPDF",
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


    $('#tblExternas tbody').on('click', 'td button.details-info', function (e) {

        var tr = $(this).closest('button');
        keyDoc = tr.attr('name');
        var jSonData = "{'key': '" + keyDoc + "'}";
        $.ajax(
            {
                url: "resumen.aspx/loadVerInfoAudit",
                data: jSonData,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    $("body").append(result.d);

                    $('#modalInfo').show();
                    $('#modalInfo').modal({ backdrop: 'static', keyboard: false });
                },
                error: function (xhr, status, error) {
                    alert("ERROR " + error.status + ' ' + error.statusText);
                }
            });

    });

    $('#tblExternas tbody').on('click', 'td button.details-ObsMas', function (e) {

            var tr = $(this).closest('button');
            keyDoc = tr.attr('name');
            var jSonData = "{'key': '" + keyDoc + "'}";
            $.ajax(
                {
                    url: "resumen.aspx/detObs",
                    data: jSonData,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {
                        $("body").append(result.d);

                        //$('#modalInfo').show();
                        //$('#modalInfo').modal({ backdrop: 'static', keyboard: false });
                    },
                    error: function (xhr, status, error) {
                        alert("ERROR " + error.status + ' ' + error.statusText);
                    }
                });


    });

    $('#tblExternas tbody').on('click', 'td button.details-ResMas', function (e) {

        var tr = $(this).closest('button');
        keyDoc = tr.attr('name');
        var jSonData = "{'key': '" + keyDoc + "'}";
        $.ajax(
            {
                url: "resumen.aspx/ResObs",
                data: jSonData,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    $("body").append(result.d);

                    //$('#modalInfo').show();
                    //$('#modalInfo').modal({ backdrop: 'static', keyboard: false });
                },
                error: function (xhr, status, error) {
                    alert("ERROR " + error.status + ' ' + error.statusText);
                }
            });


    });

    $('#tblExternas tbody').on('click', 'td button.details-Obs', function (e) {

        var tr = $(this).closest('button');
        keyDoc = tr.attr('name');
        var jSonData = "{'key': '" + keyDoc + "'}";
        $.ajax(
            {
                url: "resumen.aspx/detObs",
                data: jSonData,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    $("body").append(result.d);

                    //$('#modalInfo').show();
                    //$('#modalInfo').modal({ backdrop: 'static', keyboard: false });
                },
                error: function (xhr, status, error) {
                    alert("ERROR " + error.status + ' ' + error.statusText);
                }
            });


    });

    $('#tblExternas tbody').on('click', 'td button.details-SegNew', function (e) {
        //$('.selectpicker').html('').selectpicker('refresh');
        var tr = $(this).closest('button');
        keyDoc = tr.attr('name');
        var jSonData = "{'key': '" + keyDoc + "'}";        
        $.ajax(
            {
                url: "resumen.aspx/loadSegNew",
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

    $('#tblExternas tbody').on('click', 'td button.details-SegCorreo', function (e) {
        //$('.selectpicker').html('').selectpicker('refresh');
        $('#txtDetEmail').html('');
        $('#emailUsuario').html('');
        var tr = $(this).closest('button');
        keyDoc = tr.attr('name');
        var jSonData = "{'key': '" + keyDoc + "'}";
        $.ajax(
            {
                url: "resumen.aspx/SegCorreo",
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

    $('#tblExternas tbody').on('click', 'td button.details-pdf', function (e) {
        var tr = $(this).closest('button');
        keyDoc = tr.attr('name');
        var jSonData = "{'key': '" + keyDoc + "'}";
        $.ajax(
            {
                url: "resumen.aspx/downloadPDF",
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


    $('#tblCMF tbody').on('click', 'td button.details-info', function (e) {

        var tr = $(this).closest('button');
        keyDoc = tr.attr('name');
        var jSonData = "{'key': '" + keyDoc + "'}";
        $.ajax(
            {
                url: "resumen.aspx/loadVerInfoAudit",
                data: jSonData,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    $("body").append(result.d);

                    $('#modalInfo').show();
                    $('#modalInfo').modal({ backdrop: 'static', keyboard: false });
                },
                error: function (xhr, status, error) {
                    alert("ERROR " + error.status + ' ' + error.statusText);
                }
            });

    });

    $('#tblCMF tbody').on('click', 'td button.details-ObsMas', function (e) {

            var tr = $(this).closest('button');
            keyDoc = tr.attr('name');
            var jSonData = "{'key': '" + keyDoc + "'}";
            $.ajax(
                {
                    url: "resumen.aspx/detObs",
                    data: jSonData,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {
                        $("body").append(result.d);

                        //$('#modalInfo').show();
                        //$('#modalInfo').modal({ backdrop: 'static', keyboard: false });
                    },
                    error: function (xhr, status, error) {
                        alert("ERROR " + error.status + ' ' + error.statusText);
                    }
                });

    });

    $('#tblCMF tbody').on('click', 'td button.details-ResMas', function (e) {

        var tr = $(this).closest('button');
        keyDoc = tr.attr('name');
        var jSonData = "{'key': '" + keyDoc + "'}";
        $.ajax(
            {
                url: "resumen.aspx/ResObs",
                data: jSonData,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    $("body").append(result.d);

                    //$('#modalInfo').show();
                    //$('#modalInfo').modal({ backdrop: 'static', keyboard: false });
                },
                error: function (xhr, status, error) {
                    alert("ERROR " + error.status + ' ' + error.statusText);
                }
            });

    });

    $('#tblCMF tbody').on('click', 'td button.details-Obs', function (e) {

        var tr = $(this).closest('button');
        keyDoc = tr.attr('name');
        var jSonData = "{'key': '" + keyDoc + "'}";
        $.ajax(
            {
                url: "resumen.aspx/detObs",
                data: jSonData,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    $("body").append(result.d);

                    //$('#modalInfo').show();
                    //$('#modalInfo').modal({ backdrop: 'static', keyboard: false });
                },
                error: function (xhr, status, error) {
                    alert("ERROR " + error.status + ' ' + error.statusText);
                }
            });

    });

    $('#tblCMF tbody').on('click', 'td button.details-SegNew', function (e) {
        //$('.selectpicker').html('').selectpicker('refresh');
        var tr = $(this).closest('button');
        keyDoc = tr.attr('name');
        var jSonData = "{'key': '" + keyDoc + "'}";
        $.ajax(
            {
                url: "resumen.aspx/loadSegNew",
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

    $('#tblCMF tbody').on('click', 'td button.details-SegCorreo', function (e) {
        //$('.selectpicker').html('').selectpicker('refresh');
        $('#txtDetEmail').html('');
        $('#emailUsuario').html('');
        var tr = $(this).closest('button');
        keyDoc = tr.attr('name');
        var jSonData = "{'key': '" + keyDoc + "'}";
        $.ajax(
            {
                url: "resumen.aspx/SegCorreo",
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

    $('#tblCMF tbody').on('click', 'td button.details-pdf', function (e) {
        var tr = $(this).closest('button');
        keyDoc = tr.attr('name');
        var jSonData = "{'key': '" + keyDoc + "'}";
        $.ajax(
            {
                url: "resumen.aspx/downloadPDF",
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


   

    //**** INFO ***//

    $('#tblObservaciones tbody').on('click', 'td button.details-segs', function (e) {

        var tr = $(this).closest('button');
        keyDoc = tr.attr('name');
        var jSonData = "{'key': '" + keyDoc + "'}";
        $.ajax(
            {
                url: "lobby.aspx/loadSegs",
                data: jSonData,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    $("body").append(result.d);

                    $('#modalInfo').show();
                    $('#modalInfo').modal({ backdrop: 'static', keyboard: false });
                },
                error: function (xhr, status, error) {
                    alert("ERROR " + error.status + ' ' + error.statusText);
                }
            });

    });

    $('#tblSegObs').DataTable({
            "columns": [
            { "width": "4%" }, { "width": "4%" }, { "width": "4%" }, { "width": "10%" }, { "width": "10%" }, { "width": "40%" }, { "width": "10%" }
            ],
            "fixedColumns": true,
            "paging": false,
            "autoWidth": false,
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
            "initComplete": () => { $("#tblSeguimientos").show(); }
        }

        );



    /***** BTN *****/

    $('#regNewSeg_b').on('click', function () {//crear-Seg
        var jSonData = "{" +
            "'keyObs': '" + $("#keyObs").val() + "'," +
            "'cboEst': '" + $("#cboEst").val() + "'," +
            "'cboTipos': '" + $("#cboTipos").val() + "'," +
            "'dtFReg': '" + $("#dtFReg").val() + "'," +
            "'dtCum': '" + $("#dtCum").val() + "'," +
            "'cboUsuarios': '" + $("#cboUsuarios").val() + "'," +
            "'txtDetalle': '" + $("#txtDetalle").val() + "'," +
            "'keyRes': '" + $("#keyRes").val() + "'" +
        "}";
        $.ajax(
            {
                url: "resumen.aspx/reg",
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

    $('#enviarEmail').on('click', function () {
        $("#txtDetEmail").html($("#txtDetEmail").val().replace(/[^a-z0-9s]/gi, ""));
        var jSonData = "{" +
            "'keyObs': '" + $("#keyObs").val() + "'," +
            "'email': '" + $("#emailUsuario").text() + "'," +
            "'num': '" + $("#cboUsuariosEmail").val() + "'," +
            "'det': '" + $("#txtDetEmail").val() + "'"+
            "}";
        $.ajax(
            {
                url: "resumen.aspx/enviarEmail",
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

    $('#cboUsuariosEmail').on('change', function (e) {
       
        var jSonData = "{" +
            "'user': '" + $("#cboUsuariosEmail").val() + "'}" 
            "}";
        $.ajax(
            {
                url: "resumen.aspx/verEmail",
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

    $('#cboTipo').on('change', function (e) {
        $('#cboSubtipo').html('').selectpicker('refresh');
        var jSonData = "{" +
            "'key': '" + $("#cboTipo").val() + "'}"
        "}";
        $.ajax(
            {
                url: "resumen.aspx/verSub",
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




});
