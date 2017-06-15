//Datatables
$(document).ready(function () {
    $('#tabela').DataTable({
        "language": {
            lengthMenu: "Mostrar _MENU_ pregistros por página",
            zeroRecords: "Nenhum resultado encontrado",
            info: "Mostrando página _PAGE_ de _PAGES_",
            infoEmpty: "Não há resultados",
            infoFiltered: "(Econtrado(s) _MAX_ resultados)",
            search: "Procurar:",
            paginate: {
                first: "Primeira página",
                previous: "Página anterior",
                next: "Próxima página",
                last: "Última página"
            },
            aria: {
                sortAscending: ": classificado ascendente",
                sortDescending: ": classificado descendente"
            }
        }
    });
});