Imports MySql.Data.MySqlClient
Public Class Login
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim connection As New MySqlConnection("server=db4free.net; userid=joanneg20; password=JoanneGallarte20; database=smsystem; port=3306; old guids=true;")
        Dim command As New MySqlCommand("SELECT `username`,`password` FROM `login` WHERE `username` = @usern AND `password` = @passw", connection)
        Dim table As New DataTable()
        ' Create a MySqlDataAdapter and set its SelectCommand to the command
        Dim adapter As New MySqlDataAdapter(command)
        ' Fill the DataTable using the adapter
        adapter.Fill(table)
        If table.Rows.Count = 0 Then
            MessageBox.Show("Invalid")
        Else
            MessageBox.Show("Logged In.")
            usern.Clear()
            passw.Clear()
            Me.Hide()
            Dashboard.Show()
        End If
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Signup.Show()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        Form1.Show()

    End Sub
End Class
