Public Class Form1
    Dim d(100, 5), idx
    Sub rdata()
        FileOpen(8, "C:\Users\dora0\Desktop\8.txt", OpenMode.Input)
        idx = 0
        Do While Not EOF(8)
            idx += 1
            For i = 1 To 5
                Input(8, d(idx, i))
            Next
        Loop
        FileClose(8)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call rdata()
        Call sp1()
        Call wdata()
    End Sub
    Sub sp1()
        Dim m1, m2, m3
        For i = 1 To idx
            Select Case d(i, 3)
                Case "+"
                    m1 = d(i, 1) * d(i, 5) + d(i, 2) * d(i, 4)
                    m2 = d(i, 2) * d(i, 5)
                Case "-"
                    m1 = d(i, 1) * d(i, 5) - d(i, 2) * d(i, 4)
                    m2 = d(i, 2) * d(i, 5)
                Case "*"
                    m1 = d(i, 1) * d(i, 4)
                    m2 = d(i, 2) * d(i, 5)
                Case "/"
                    m1 = d(i, 1) * d(i, 5)
                    m2 = d(i, 2) * d(i, 4)
            End Select
            For j = 2 To Math.Abs(m1)
                Do While m1 Mod j = 0 And m2 Mod j = 0
                    m1 = m1 / j
                    m2 = m2 / j
                Loop
            Next
            m3 = m1 & "/" & m2
            If m1 = 0 Then m3 = 0
            If m2 = 1 Then m3 = m1
            d(i, 0) = m3
        Next
    End Sub
    Sub wdata()
        Dim table As New DataTable
        table.Columns.Add("VALUE1")
        table.Columns.Add("OP")
        table.Columns.Add("VALUE2")
        table.Columns.Add("ANSWER")
        For i = 1 To idx
            Dim tr As DataRow = table.NewRow
            tr(0) = d(i, 1) & "/" & d(i, 2)
            tr(1) = d(i, 3)
            tr(2) = d(i, 4) & "/" & d(i, 5)
            tr(3) = d(i, 0)
            table.Rows.Add(tr)
        Next
        dgv.DataSource = table
        dgv.DefaultCellStyle.Alignment = 32



    End Sub
End Class
