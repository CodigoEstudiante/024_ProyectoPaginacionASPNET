<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <link href="https://cdn.datatables.net/1.10.24/css/jquery.dataTables.min.css" rel="stylesheet" />
</head>
<body>

    <table id="mitabla" class="display" style="width:100%">
        <thead>
            <tr>
               <th>OrderId</th>
               <th>CustomerID</th>
               <th>ShipAddress</th>
               <th>ShipCountry</th>
            </tr>
        </thead>
        <tbody>
           
        </tbody>
    </table>

</body>
    <script src="https://code.jquery.com/jquery-3.5.1.js" type="text/javascript"></script>
    <script src="https://cdn.datatables.net/1.10.24/js/jquery.dataTables.min.js" type="text/javascript"></script>

    <script type="text/javascript">

        $(document).ready(function() {

            $('#mitabla').DataTable({
                "processing": true,
                "serverSide": true,
                ajax: {
                    type :"POST",
                    url: "WebForm1.aspx/obtener",
                    contentType: 'application/json; charset=utf-8',
                    dataType: "json",
                    data: function (dtParms) {
                        //enviamos al servidor
                        return JSON.stringify({ ClientParameters: JSON.stringify(dtParms) });
                    },
                    dataFilter: function (res) {
                        //recibimos del servidor
                        var parsed = JSON.parse(res);
                        return JSON.stringify(parsed.d);
                    },
                    error: function (x, y) {
                        console.log(x);
                    }
                },
                "filter": true,
                columns: [
                    {"data":"OrderId"},
                    {"data":"CustomerID"},
                    {"data":"ShipAddress"},
                    {"data":"ShipCountry"}
                ],
                "language": {
                    "url": "http://cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                }

            });



        });


    </script>

</html>
