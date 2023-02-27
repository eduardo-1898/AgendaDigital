$(document).ready(function () {

    $('#eliminar').change(function () {
        if (this.checked) {
            $('#deleteButton').removeClass('disabled');
        }
        else {
            $('#deleteButton').addClass('disabled');
        }
    });

    $('#clienteadd').change(function () {
        $.ajax({
            url: resolveUrl('~/Home/GetCustomerById?id=' + $('#clienteadd').val()),
            type: 'GET',
            contentType: false,
            processData: false,
            success: function (data) {
                if (data == "") {
                    $('#NuevoCliente').prop('checked', true);
                } else {
                    $('#NuevoCliente').prop('checked', false);
                    $('#clienteadd').val(data.cliente);
                    $('#idCliente').val(data.codigo);
                    $('#modalAddEvents').appendTo("body").modal('show');
                }
            }
        })
    });

    $('#clienteUpdate').change(function () {
        $.ajax({
            url: resolveUrl('~/Home/GetCustomerById?id=' + $('#clienteUpdate').val()),
            type: 'GET',
            contentType: false,
            processData: false,
            success: function (data) {
                if (data == "") {
                    $('#NuevoClienteUpdate').prop('checked', true);
                } else {
                    $('#NuevoClienteUpdate').prop('checked', false);
                    $('#clienteUpdate').val(data.cliente);
                    $('#modalAddEvents').appendTo("body").modal('show');
                }
            }
        })
    });

    $("#sucursal").change(function () {
        $("#vehiculo").empty();
        $.ajax({
            url: resolveUrl('~/Home/GetVehiclesAvailable?Almacen=' + $('#sucursal').val() + '&Fecha=' + $('#Fecha').val() + '&HoraInicio=' + $('#HoraEntrada').val() + '&HoraFinal=' + $('#HoraSalida').val()),
            type: 'GET',
            contentType: false,
            processData: false,
            success: function (data) {

                const config = {
                    search: true,
                    creatable: false,
                    clearable: false,
                    maxHeight: '360px',
                    size: '',
                }
                
                if (data.length > 0) {
                    $.each(data, function (key, value) {
                        $("#vehiculo").append('<option value="' + value.serieLote + '">' + value.serieLote + '</option>');
                    });
                    dselect(document.querySelector('#vehiculo'), config);
                }
                else {
                    $("#vehiculo").append('<option value="">Sin resultados</option>');
                    dselect(document.querySelector('#vehiculo'), config);
                }

            }
        })

    });

    $("#sucursalUpdate").change(function () {
        $("#vehiculoupdate").empty();
        $.ajax({
            url: resolveUrl('~/Home/GetVehiclesAvailable?Almacen=' + $('#sucursalUpdate').val() + '&Fecha=' + $('#FechaUpdate').val() + '&HoraInicio=' + $('#HoraEntradaUpdate').val() + '&HoraFinal=' + $('#HoraSalidaUpdate').val()),
            type: 'GET',
            contentType: false,
            processData: false,
            success: function (data) {

                const config = {
                    search: true,
                    creatable: false,
                    clearable: false,
                    maxHeight: '360px',
                    size: '',
                }

                if (data.length > 0) {
                    $.each(data, function (key, value) {
                        $("#vehiculoupdate").append('<option value="' + value.serieLote + '">' + value.serieLote + '</option>');
                    });
                    dselect(document.querySelector('#vehiculoupdate'), config);
                }
                else {
                    $("#vehiculoupdate").append('<option value="">Sin resultados</option>');
                    dselect(document.querySelector('#vehiculoupdate'), config);
                }

            }
        })

    });

    $("#Fecha").change(function () {
        if ($("#sucursal").val()!="") {
            $("#vehiculo").empty();
            $.ajax({
                url: resolveUrl('~/Home/GetVehiclesAvailable?Almacen=' + $('#sucursal').val() + '&Fecha=' + $('#Fecha').val() + '&HoraInicio=' + $('#HoraEntrada').val() + '&HoraFinal=' + $('#HoraSalida').val()),
                type: 'GET',
                contentType: false,
                processData: false,
                success: function (data) {

                    const config = {
                        search: true,
                        creatable: false,
                        clearable: false,
                        maxHeight: '360px',
                        size: '',
                    }
                    if (data.length > 0) {
                        $.each(data, function (key, value) {
                            $("#vehiculo").append('<option value="' + value.serieLote + '">' + value.serieLote + '</option>');
                        });
                        dselect(document.querySelector('#vehiculo'), config);
                    }
                    else {
                        $("#vehiculo").append('<option value="">Sin resultados</option>');
                        dselect(document.querySelector('#vehiculo'), config);
                    }

                }
            })
        }

    });

    $("#HoraEntrada").change(function () {
        if ($("#sucursal").val() != "") {
            $("#vehiculo").empty();
            $.ajax({
                url: resolveUrl('~/Home/GetVehiclesAvailable?Almacen=' + $('#sucursal').val() + '&Fecha=' + $('#Fecha').val() + '&HoraInicio=' + $('#HoraEntrada').val() + '&HoraFinal=' + $('#HoraSalida').val()),
                type: 'GET',
                contentType: false,
                processData: false,
                success: function (data) {

                    const config = {
                        search: true,
                        creatable: false,
                        clearable: false,
                        maxHeight: '360px',
                        size: '',
                    }
                    if (data.length > 0) {
                        $.each(data, function (key, value) {
                            $("#vehiculo").append('<option value="' + value.serieLote + '">' + value.serieLote + '</option>');
                        });
                        dselect(document.querySelector('#vehiculo'), config);
                    }
                    else {
                        $("#vehiculo").append('<option value="">Sin resultados</option>');
                        dselect(document.querySelector('#vehiculo'), config);
                    }

                }
            })
        }

    });

    $("#HoraSalida").change(function () {
        if ($("#sucursal").val() != "") {
            $("#vehiculo").empty();
            $.ajax({
                url: resolveUrl('~/Home/GetVehiclesAvailable?Almacen=' + $('#sucursal').val() + '&Fecha=' + $('#Fecha').val() + '&HoraInicio=' + $('#HoraEntrada').val() + '&HoraFinal=' + $('#HoraSalida').val()),
                type: 'GET',
                contentType: false,
                processData: false,
                success: function (data) {

                    const config = {
                        search: true,
                        creatable: false,
                        clearable: false,
                        maxHeight: '360px',
                        size: '',
                    }
                    if (data.length > 0) {
                        $.each(data, function (key, value) {
                            $("#vehiculo").append('<option value="' + value.serieLote + '">' + value.serieLote + '</option>');
                        });
                        dselect(document.querySelector('#vehiculo'), config);
                    }
                    else {
                        $("#vehiculo").append('<option value="">Sin resultados</option>');
                        dselect(document.querySelector('#vehiculo'), config);
                    }

                }
            })
        }

    });


    $("#FechaUpdate").change(function () {
        if ($("#sucursalUpdate").val() != "") {
            $("#vehiculoupdate").empty();
            $.ajax({
                url: resolveUrl('~/Home/GetVehiclesAvailable?Almacen=' + $('#sucursalUpdate').val() + '&Fecha=' + $('#FechaUpdate').val() + '&HoraInicio=' + $('#HoraEntradaUpdate').val() + '&HoraFinal=' + $('#HoraSalidaUpdate').val()),
                type: 'GET',
                contentType: false,
                processData: false,
                success: function (data) {

                    const config = {
                        search: true,
                        creatable: false,
                        clearable: false,
                        maxHeight: '360px',
                        size: '',
                    }
                    if (data.length > 0) {
                        $.each(data, function (key, value) {
                            $("#vehiculoupdate").append('<option value="' + value.serieLote + '">' + value.serieLote + '</option>');
                        });
                        dselect(document.querySelector('#vehiculoupdate'), config);
                    }
                    else {
                        $("#vehiculoupdate").append('<option value="">Sin resultados</option>');
                        dselect(document.querySelector('#vehiculoupdate'), config);
                    }

                }
            })
        }

    });

    $("#HoraEntradaUpdate").change(function () {
        if ($("#sucursalUpdate").val() != "") {
            $("#vehiculoupdate").empty();
            $.ajax({
                url: resolveUrl('~/Home/GetVehiclesAvailable?Almacen=' + $('#sucursalUpdate').val() + '&Fecha=' + $('#FechaUpdate').val() + '&HoraInicio=' + $('#HoraEntradaUpdate').val() + '&HoraFinal=' + $('#HoraSalidaUpdate').val()),
                type: 'GET',
                contentType: false,
                processData: false,
                success: function (data) {

                    const config = {
                        search: true,
                        creatable: false,
                        clearable: false,
                        maxHeight: '360px',
                        size: '',
                    }
                    if (data.length > 0) {
                        $.each(data, function (key, value) {
                            $("#vehiculoupdate").append('<option value="' + value.serieLote + '">' + value.serieLote + '</option>');
                        });
                        dselect(document.querySelector('#vehiculoupdate'), config);
                    }
                    else {
                        $("#vehiculoupdate").append('<option value="">Sin resultados</option>');
                        dselect(document.querySelector('#vehiculoupdate'), config);
                    }

                }
            })
        }

    });

    $("#HoraSalidaUpdate").change(function () {
        if ($("#sucursalUpdate").val() != "") {
            $("#vehiculoupdate").empty();
            $.ajax({
                url: resolveUrl('~/Home/GetVehiclesAvailable?Almacen=' + $('#sucursalUpdate').val() + '&Fecha=' + $('#FechaUpdate').val() + '&HoraInicio=' + $('#HoraEntradaUpdate').val() + '&HoraFinal=' + $('#HoraSalidaUpdate').val()),
                type: 'GET',
                contentType: false,
                processData: false,
                success: function (data) {

                    const config = {
                        search: true,
                        creatable: false,
                        clearable: false,
                        maxHeight: '360px',
                        size: '',
                    }
                    if (data.length > 0) {
                        $.each(data, function (key, value) {
                            $("#vehiculoupdate").append('<option value="' + value.serieLote + '">' + value.serieLote + '</option>');
                        });
                        dselect(document.querySelector('#vehiculoupdate'), config);
                    }
                    else {
                        $("#vehiculoupdate").append('<option value="">Sin resultados</option>');
                        dselect(document.querySelector('#vehiculoupdate'), config);
                    }

                }
            })
        }

    });


    $("#btnBloquear").click(function () {
        var formData = new FormData();
        formData.append('FechaInicio', $('#FechaInicioBlock').val());
        formData.append('FechaFin', $('#FechaFinBlock').val());
        formData.append('Vehiculo', $('#vehiculoblock').val());
        formData.append('Comentario', $('#comentarioBlock').val());

        $.ajax({
            url: resolveUrl('~/Home/CreateStucsVehicles'),
            data: formData,
            processData: false,
            type: 'POST',
            contentType: false,
            success: function (data) {
                if (data) {

                    $('#FechaInicioBlock').val('');
                    $('#FechaFinBlock').val('');
                    $('#comentarioBlock').val('');

                    Swal.fire({
                        title: 'Éxito',
                        text: "Bloqueo agregado exitosamente",
                        icon: 'success',
                        confirmButtonText: 'Ok'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            location.reload();
                        }
                    });
                }
                else {
                    Swal.fire(
                        'Upps!',
                        'Algo salió mal, no se logró registrar el bloqueo',
                        'error'
                    )
                }
            },
            error: function (errormessage) {
                debugger;
                Swal.fire(
                    'Upps!',
                    errormessage.responseText,
                    'info'
                )
            }
        })

    });

    $("#deleteButton").click(function () {
        var formData = new FormData();
        formData.append('id', $('#idupdate').val());

        $.ajax({
            url: resolveUrl('~/Home/DeleteActivities'),
            data: formData,
            processData: false,
            type: 'DELETE',
            contentType: false,
            success: function (data) {
                if (data) {
                    Swal.fire({
                        title: 'Éxito',
                        text: "Registro eliminado correctamente",
                        icon: 'success',
                        confirmButtonText: 'Ok'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            location.reload();
                        }
                    })
                }
                else {
                    Swal.fire(
                        'Upps!',
                        'Algo salió mal, no se logró registrar el bloqueo',
                        'error'
                    )
                }
            }
        })

    });

    $("#updateButton").click(function () {

        var formData = new FormData();
        formData.append('Fecha', $('#FechaUpdate').val());
        formData.append('horaInicio', $('#HoraEntradaUpdate').val());
        formData.append('horaFinal', $('#HoraSalidaUpdate').val());
        formData.append('cliente', $('#clienteUpdate').val());
        formData.append('sucursal', $('#sucursalUpdate').val());
        formData.append('idVehiculo', $("#vehiculoupdate").val());
        formData.append('id', $("#idupdate").val());
        formData.append('NuevoCliente', $("#NuevoClienteUpdate").val());

        $.ajax({
            url: resolveUrl('~/Home/UpdateActivities'),
            data: formData,
            processData: false,
            type: 'PUT',
            contentType: false,
            success: function (data) {
                if (data) {
                    Swal.fire({
                        title: 'Éxito',
                        text: "Reserva actualizada correctamente",
                        icon: 'success',
                        confirmButtonText: 'Ok'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            location.reload();
                        }
                    })
                }
                else {
                    Swal.fire(
                        'Upps!',
                        'Algo salió mal, no se logró actualizar la reserva',
                        'error'
                    )
                }
            }
        })

    });

    $("#btnagregar").click(function () {
        var formData = new FormData();
        formData.append('Fecha', $('#Fecha').val());
        formData.append('horaInicio', $('#HoraEntrada').val());
        formData.append('horaFinal', $('#HoraSalida').val());
        formData.append('NuevoCliente', $('#NuevoCliente').val());
        formData.append('cliente', $('#clienteadd').val());
        formData.append('sucursal', $('#sucursal').val());
        formData.append('idVehiculo', $("#vehiculo").val());

        $.ajax({
            url: resolveUrl('~/Home/CreateActivities'),
            data: formData,
            processData: false,
            type: 'POST',
            contentType: false,
            success: function (data) {
                if (data) {
                    $('#Fecha').val('')
                    $('#HoraEntrada').val('')
                    $('#HoraSalida').val('');
                    $('#NuevoCliente').val('');
                    $('#clienteadd').val('');
                    $('#sucursal').val('');
                    $("#vehiculo").empty();

                    Swal.fire({
                        title: 'Éxito',
                        text: "Reserva agregada exitosamente",
                        icon: 'success',
                        confirmButtonText: 'Ok'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            location.reload();
                        }
                    });
                }
                else {
                    Swal.fire(
                        'Upps!',
                        'Algo salió mal, no se logró registrar la reserva',
                        'error'
                    )
                }
            }
        })

    });

});