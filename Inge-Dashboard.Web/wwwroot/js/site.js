// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/**
 * Metodo para la generacion del grafico de distribucion de productos adjudicados
 * @param {any} arrDatos
 */
function GenerarGraficoDistribucionProductos(arrDatos) {
    var clasificacionLabel = arrDatos.map(dt => dt.clasificacionOnu);
    var cantidadData = arrDatos.map(dt => dt.cantidad);

    var ctx = document.getElementById("graficoDistriProducto");
    var myPieChart2 = new Chart(ctx, {
        type: 'doughnut',
        data: {
            labels: clasificacionLabel,
            datasets: [{
                label: "Distribucion de productos licitados",
                data: cantidadData,
                backgroundColor: ['#4e73df', '#1cc88a', '#36b9cc', 'rgb(254,000,000)', 'rgb(255, 191, 0)'],
                borderWidth: 1
            }]
        },

        options: {
            maintainAspectRatio: false,
            legend: {
                display: true,
                position: 'left',

            }
        }
    });
}

function generarGraficoLicitacionesMensuales(arrDato) {
    var mesAnnoLabels;
    var licAdjuntadasData;
    var licParticipadasData;
    if (arrDato != null) {

        mesAnnoLabels = arrDato.map(dt => dt.mesAnno);
        licAdjuntadasData = arrDato.map(dt => dt.licitacionesAdjudicadas);
        licParticipadasData = arrDato.map(dt => dt.licitacionesParticipadas);

    }

    var canvas = document.getElementById("resumenNumLicitaciones");
    var ctx = canvas.getContext('2d');


    var data = {
        labels: mesAnnoLabels,
        datasets: [{
            label: "Adjudicadas",
            fill: true,
            lineTension: 0.1,
            backgroundColor: "rgba(78, 115, 223, 0.05)",
            borderColor: "rgba(78, 115, 223, 1)",
            pointRadius: 3,
            pointBackgroundColor: "rgba(78, 115, 223, 1)",
            pointBorderColor: "rgba(78, 115, 223, 1)",
            pointHoverRadius: 8,
            pointHoverBackgroundColor: "rgba(78, 115, 223, 1)",
            pointHoverBorderColor: "rgba(78, 115, 223, 1)",
            pointHitRadius: 10,
            pointBorderWidth: 2,
            pointStyle: "rectRot",
            // notice the gap in the data and the spanGaps: true
            data: licAdjuntadasData,
        }, {
            label: "Participadas",
            fill: true,
            lineTension: 0.1,
            backgroundColor: "rgba(167,105,0,0.4)",
            borderColor: "rgb(167, 105, 0)",
            borderCapStyle: 'butt',
            borderDash: [],
            borderDashOffset: 0.0,
            borderJoinStyle: 'miter',
            pointBorderColor: "white",
            pointBackgroundColor: "rgb(167, 105, 0)",
            pointBorderWidth: 1,
            pointHoverRadius: 8,
            pointHoverBackgroundColor: "brown",
            pointHoverBorderColor: "black",
            pointHoverBorderWidth: 2,
            pointStyle: "rectRot",
            pointRadius: 4,
            pointHitRadius: 10,
            // notice the gap in the data and the spanGaps: false
            data: licParticipadasData,
        }

        ]
    };

    // Notice the scaleLabel at the same level as Ticks
    var options = {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true
                },
                scaleLabel: {
                    display: true,
                    labelString: 'N° Licitaciones',
                    fontSize: 20
                }
            }]
        },
        legend: {
            display: true,
            position: 'bottom',

        },
        tooltips: {
            enabled: true,
            mode: 'label',
            //mode: 'index',
            //intersect: false,
        },
        //hover: {
        //    mode: 'neareast',
        //    intersect:true
        //}
    };

    // Chart declaration:
    var myBarChart = new Chart(ctx, {
        type: 'line',
        data: data,
        options: options
    });

}



function generarGraficoTotalesNetoAdjudicadoMensuales(arrDato) {
    var mesAnnoLabels;
    var totalesMensualesData;
    if (arrDato != null) {
        mesAnnoLabels = arrDato.map(dt => dt.mesAnno)
        totalesMensualesData = arrDato.map(dt => dt.totalNetoAdjudicado)
    }

    var canvas = document.getElementById("graficoNetoAdjudicadoMensual");
    var ctx = canvas.getContext('2d');

    var data = {
        labels: mesAnnoLabels,
        datasets: [{
            label: "Total",
            fill: true,
            lineTension: 0.1,
            backgroundColor: "rgba(78, 115, 223, 0.05)",
            borderColor: "rgba(78, 115, 223, 1)",
            pointRadius: 3,
            pointBackgroundColor: "rgba(78, 115, 223, 1)",
            pointBorderColor: "rgba(78, 115, 223, 1)",
            pointHoverRadius: 8,
            pointHoverBackgroundColor: "rgba(78, 115, 223, 1)",
            pointHoverBorderColor: "rgba(78, 115, 223, 1)",
            pointHitRadius: 10,
            pointBorderWidth: 2,
            pointStyle: "rectRot",
            // notice the gap in the data and the spanGaps: true
            data: totalesMensualesData,
            spanGaps: true,
        }
        ]
    };

    var options = {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true,
                    callback: function (value, index, values) {
                        return '$' + number_format(value);
                    }
                },
                scaleLabel: {
                    display: true,
                    labelString: 'Total $ Millones',
                    fontSize: 20
                }
            }]
        },
        legend: {
            display: true,
            position: 'bottom',

        },
        tooltips: {
            titleMarginBottom: 10,
            titleFontColor: '#6e707e',
            titleFontSize: 14,
            backgroundColor: "rgb(255,255,255)",
            bodyFontColor: "#858796",
            borderColor: '#dddfeb',
            borderWidth: 1,
            xPadding: 15,
            yPadding: 15,
            displayColors: false,
            caretPadding: 10,
            callbacks: {
                label: function (tooltipItem, chart) {
                    var datasetLabel = chart.datasets[tooltipItem.datasetIndex].label || '';
                    return datasetLabel + ': $' + number_format(tooltipItem.yLabel) + ' Millones';
                }
            }
        }
    };

    // Chart declaration:
    var myBarChart = new Chart(ctx, {
        type: 'line',
        data: data,
        options: options
    });
}








function number_format(number, decimals, dec_point, thousands_sep) {
    // *     example: number_format(1234.56, 2, ',', ' ');
    // *     return: '1 234,56'
    number = (number + '').replace(',', '').replace(' ', '');
    var n = !isFinite(+number) ? 0 : +number,
        prec = !isFinite(+decimals) ? 0 : Math.abs(decimals),
        sep = (typeof thousands_sep === 'undefined') ? '.' : thousands_sep,
        dec = (typeof dec_point === 'undefined') ? ',' : dec_point,
        s = '',
        toFixedFix = function (n, prec) {
            var k = Math.pow(10, prec);
            return '' + Math.round(n * k) / k;
        };
    // Fix for IE parseFloat(0.55).toFixed(0) = 0;
    s = (prec ? toFixedFix(n, prec) : '' + Math.round(n)).split('.');
    if (s[0].length > 3) {
        s[0] = s[0].replace(/\B(?=(?:\d{3})+(?!\d))/g, sep);
    }
    if ((s[1] || '').length < prec) {
        s[1] = s[1] || '';
        s[1] += new Array(prec - s[1].length + 1).join('0');
    }
    return s.join(dec);
}