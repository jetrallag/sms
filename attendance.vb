Imports MySql.Data.MySqlClient
Public Class attendance
    Dim con As MySqlConnection
    Dim cnstr As String = "server=db4free.net; userid=joanneg20; password=JoanneGallarte20; database=smsystem; port=3306; old guids=true;"
    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim ds As DataSet
    Dim itemcoll(999) As String
    Dim timesa As Integer
    Dim timesp As Integer
    Dim total As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dashboard.Show()
        Me.Close()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = Val(TA.Text) + Val(TextBox2.Text)
        Try
            con = New MySqlConnection(cnstr)
            con.Open()
            Dim sql As String = ("UPDATE students SET absent=@abs where stn = @stno")
            cmd = New MySqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@stno", stno.Text)
            cmd.Parameters.AddWithValue("@abs", TextBox1.Text)
            Dim i As Integer = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("The STUDENT Was ABSENT TODAY!!")
                fname.Clear()
                stno.Clear()
                TP.Clear()
                TA.Clear()
                Call ListViewData()
            Else
                MsgBox("The STUDENT DETAILS Cannot Be UPDATED!")
            End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
        If ListView1.SelectedItems.Count > 0 Then
            fname.Text = ListView1.Items(ListView1.SelectedIndices(0)).Text
            stno.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(4).Text
            TA.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(7).Text
            TP.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(8).Text
        End If
    End Sub

    Private Sub PROFILE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListViewData()
        TextBox2.Text = 1
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox1.Text = Val(TP.Text) + Val(TextBox2.Text)
        Try
            con = New MySqlConnection(cnstr)
            con.Open()
            Dim sql As String = ("UPDATE students SET present=@abs where stn = @stno")
            cmd = New MySqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@stno", stno.Text)
            cmd.Parameters.AddWithValue("@abs", TextBox1.Text)
            Dim i As Integer = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("The STUDENT Was PRESENT TODAY!")
                fname.Clear()
                stno.Clear()
                TP.Clear()
                TA.Clear()
                Call ListViewData()
            Else
                MsgBox("The STUDENT DETAILS Cannot Be UPDATED!")
            End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function TextBox1() As Object
        Throw New NotImplementedException
    End Function

    Private Function TextBox2() As Object
        Throw New NotImplementedException
    End Function

End Class