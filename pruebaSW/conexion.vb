Imports System.Data.SqlClient
Module conexion

    'Public cnn As String = "Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;"

    Dim dbServer As String = "localhost\SQLEXPRESS"
    Dim dbName As String = "pruebaSW"

    'Public cnn As New SqlConnection("Initial Catalog=Northwind;Data Source=localhost;Integrated Security=SSPI;")
    Public cnn As New SqlConnection("Server=" & dbServer & ";Database=" & dbName & ";Trusted_Connection=True;")

End Module
