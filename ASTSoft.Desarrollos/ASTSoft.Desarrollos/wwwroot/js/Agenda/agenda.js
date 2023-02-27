$(document).ready(function () {


    $.ajax({
        url: resolveUrl("~/Home/GetActivities"),
        type: 'GET',
        contentType: false,
        processData: false,
        success: function (data) {
            var events = [];
            $.each(data, function (idx, element) {
                events.push({
                    'id': element.id,
                    'title': element.idVehiculo,
                    'start': element.fechaInicio,
                    'end': element.fechaFinal,
                    'allDay': false,
                    'color': '#2C3E50',
                    'textColor': "white"
                });
            });

            var calendarEl = document.getElementById('calendar');

            var calendar = new FullCalendar.Calendar(calendarEl, {
                timeZone: 'UTC',
                themeSystem: 'bootstrap5',
                locale: 'es',
                navLinks: true,
                customButtons: {
                    addEvents: {
                        text: 'Nuevo registro',
                        click: function () {
                            $('#modalAddEvents').appendTo("body").modal('show');
                        }
                    },
                    addBloking: {
                        text: 'Bloquear',
                        click: function () {
                            $('#modalAddBlock').appendTo("body").modal('show');
                        }
                    }
                },
                headerToolbar: {
                    left: 'prev,next today addEvents addBloking',
                    center: 'title',
                    right: 'dayGridMonth,listMonth'
                },
                dayMaxEvents: true,
                eventClick: function (callEvent) {
                    $.ajax({
                        url: resolveUrl('~/Home/GetActivitiesById?id=' + callEvent.event.id),
                        type: 'GET',
                        contentType: false,
                        processData: false,
                        success: function (data) {

                            $('#modaltittle').html(callEvent.event.title);
                            $('#clienteUpdate').val(data.cliente);
                            $('#FechaUpdate').val(data.fechajs);
                            $('#HoraEntradaUpdate').val(data.horaInjs);
                            $('#HoraSalidaUpdate').val(data.horaFinjs);
                            $('#sucursalUpdate').val(data.sucursal);
                            $("#vehiculoupdate").val(data.idVehiculo);
                            $("#idupdate").val(data.id)

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

                            $('#modalAgenda').appendTo("body").modal('show');
                        }
                    })
                },
                events: events
            });
            calendar.render();

        }
    })

});