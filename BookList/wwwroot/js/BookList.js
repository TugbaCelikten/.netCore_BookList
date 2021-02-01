var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/Book",
            "method": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "bookName", "width": "20%" },
            { "data": "bookAuthor", "width": "20%" },
            { "data": "isbn", "width": "20%" },
            {
                "data": "bookId",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="/BookList/Edit?id=${data}" class='btn btn-success text-white' 
                                style='cursor:pointer; width:70px;'>Edit</a>
                            &nbsp;
                            <a onclick=Delete('/api/Book?id='+${data}) class='btn btn-danger text-white' style='cursor:pointer; width:70px;'>Delete</a>
                            </div>`
                },
                "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "Data cannot be found!"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "This book will be deleted. Are you sure?",
        text: "This process cannot be retaken!",
        icon: "Warning",
        buttons: true,
        dangerMode: true
    }).then((willbeitdeleted) => {
        if (willbeitdeleted) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {toastr.error(data.message)}
                }
            })
        }
    })
}