Imports MySql.Data.MySqlClient
Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim connection As New MySqlConnection("server=db4free.net; userid=joanneg20; password=JoanneGallarte20; database=smsystem; port=3306; old guids=true;")
        Dim command As New MySqlCommand("SELECT `rfid` FROM `login` WHERE `rfid` = @rfid", connection)
        Dim table As New DataTable()
        If table.Rows.Count = 0 Then
            MessageBox.Show("Invalid")
        Else
            MessageBox.Show("Logged In.")
            rfid.Clear()
            Me.Hide()
            Dashboard.Show()
        End If
    End Sub
End Class