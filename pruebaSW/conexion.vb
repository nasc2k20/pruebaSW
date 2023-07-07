Imports System.Data.SqlClient
Module conexion

    'Public cnn As String = "Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;"

    Dim dbServer As String = "DB-TECH"
    Dim dbName As String = "pruebaSW"
    Dim dbUser As String = "sa"
    Dim dbPassword As String = "Db$2023"

    Public cnn As New SqlConnection("Data Source=" & dbServer & ";Initial Catalog=" & dbName & ";
                                        User ID=" & dbUser & "; password=" & dbPassword & ";")

End Module
