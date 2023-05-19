Imports MySql.Data.MySqlClient
Public Class Sign
    Dim con As MySqlConnection
    Dim cnstr As String = "server=db4free.net; userid=joanneg20; password=JoanneGallarte20; database=smsystem; port=3306; old guids=true;"
    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            con = New MySqlConnection(cnstr)
            con.Open()
            Dim sql As String = "Insert into students(name,address,pnum,email,stn,gender, cys) VALUES(@fname,@add,@phone,@email,@stdno,@gen,@crs)"
            cmd = New MySqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@fname", fname.Text)
            cmd.Parameters.AddWithValue("@add", addr.Text)
            cmd.Parameters.AddWithValue("@phone", pno.Text)
            cmd.Parameters.AddWithValue("@email", email.Text)
            cmd.Parameters.AddWithValue("@stdno", stno.Text)
            cmd.Parameters.AddWithValue("@gen", gender.Text)
            cmd.Parameters.AddWithValue("@crs", cys.Text)
            Dim i As Integer = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("The STUDENT DETAILS Was Successfully Registered!")
                fname.Clear()
                addr.Clear()
                pno.Clear()
                email.Clear()
                stno.Clear()
                gender.Clear()
                cys.Clear()
            Else
                MsgBox("The STUDENT DETAILS Cannot Be Saved!")
            End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dashboard.Show()
        Me.Close()
    End Sub

    Private Sub cys_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class