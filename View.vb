Imports MySql.Data.MySqlClient
Public Class View
    Dim con As MySqlConnection
    Dim cnstr As String = "server=db4free.net; userid=joanneg20; password=JoanneGallarte20; database=smsystem; port=3306; old guids=true;"
    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim ds As DataSet
    Dim itemcoll(999) As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dashboard.Show()
        Me.Close()

    End Sub
    Private Sub Viewattendance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListViewData()
    End Sub
    Public Sub ListViewData()
        Try
            ListView1.Items.Clear()
            con = New MySqlConnection(cnstr)
            con.Open()
            Dim sql As String = "SELECT * FROM students"
            cmd = New MySqlCommand(sql, con)
            da = New MySqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "table")
            For r = 0 To ds.Tables(0).Rows.Count - 1
                For c = 0 To ds.Tables(0).Columns.Count - 1
                    itemcoll(c) = ds.Tables(0).Rows(r)(c).ToString
                Next
                Dim lvitem As New ListViewItem(itemcoll)
                ListView1.Items.Add(lvitem)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class
