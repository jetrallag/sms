Imports MySql.Data.MySqlClient
Public Class PROFILE


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
            addr.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(1).Text
            pno.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(2).Text
            email.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(3).Text
            stno.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(4).Text
            gender.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(5).Text
            cys.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(6).Text
        End If
    End Sub

    Private Sub PROFILE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListViewData()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            con = New MySqlConnection(cnstr)
            con.Open()
            Dim sql As String = "UPDATE students SET name = @name, address = @add, pnum = @phone, email =@emailadd, gender = @gen, cys =@yands where stn = @stno"
            cmd = New MySqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@name", fname.Text)
            cmd.Parameters.AddWithValue("@add", addr.Text)
            cmd.Parameters.AddWithValue("@phone", pno.Text)
            cmd.Parameters.AddWithValue("@emailadd", email.Text)
            cmd.Parameters.AddWithValue("@stno", stno.Text)
            cmd.Parameters.AddWithValue("@gen", gender.Text)
            cmd.Parameters.AddWithValue("@yands", cys.Text)
            Dim i As Integer = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("The STUDENT DETAILS Was Successfully UPDATED!")
                fname.Clear()
                addr.Clear()
                pno.Clear()
                email.Clear()
                stno.Clear()
                gender.Clear()
                cys.Clear()
                Call ListViewData()
            Else
                MsgBox("The STUDENT DETAILS Cannot Be UPDATED!")
            End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            con = New MySqlConnection(cnstr)
            con.Open()
            Dim sql As String = "DELETE FROM students Where stn = @stn"
            cmd = New MySqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@stn", stno.Text)
            Dim i As Integer = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("The Students Record Was Deleted Successfully!")
                fname.Clear()
                addr.Clear()
                email.Clear()
                gender.Clear()
                cys.Clear()
                pno.Clear()
                stno.Clear()
                Call ListViewData()
            Else
                MsgBox("The Students Record Cannot Be Deleted!")
                Call ListViewData()
            End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class