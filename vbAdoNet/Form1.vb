Imports System.Data.SqlClient
Imports System.Configuration

Public Class Form1
    Dim cs As String = ConfigurationManager.ConnectionStrings("pubsConnectionString").ConnectionString

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlcmd As String = "SELECT * FROM Authors"
        Dim cString As String = ""
        Dim connString As String = GetConnectionString(cString)
        Dim conn As New SqlConnection(connString)
        Try
            conn.Open()
            Dim sqlDa As New SqlDataAdapter(sqlcmd, conn)
            Dim dt As New DataTable
            sqlDa.Fill(dt)
            DataGridView1.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Public Shared Function GetConnectionString(ByVal strConnection As String) As String
        'Declare a string to hold the connection string
        Dim sReturn As New String("")
        'Check to see if they provided a connection string name
        If Not String.IsNullOrEmpty(strConnection) Then
            'Retrieve the connection string from the app.config
            sReturn = ConfigurationManager.ConnectionStrings(strConnection).ConnectionString
        Else
            'Since they didnt provide the name of the connection string
            'just grab the default on from app.config
            sReturn = ConfigurationManager.ConnectionStrings("pubsConnectionString").ConnectionString()
        End If
        'Return the connection string to the calling method
        Return sReturn
    End Function

End Class
