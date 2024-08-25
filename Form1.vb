Public Class Form1
    Dim d(100, 5), rno
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call rdata()
        Call sp1()
        Call wdata()
    End Sub

    Sub rdata()
        FileOpen(8, "C:\Users\dora0\Desktop\8.txt", OpenMode.Input)
        rno = 0
        Do While Not EOF(8)
            rno = rno + 1
            For j = 1 To 5
                Input(8, d(rno, j))
            Next
        Loop
        FileClose(8)
    End Sub

    Sub sp1()
        Dim m1, m2, m3

        For i = 1 To rno
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
                    m1 = m1 / j : m2 = m2 / j
                Loop
            Next

            m3 = m1 & "/" & m2
            If m1 = 0 Then m3 = 0
            If m2 = 1 Then m3 = m1
            d(i, 0) = m3
        Next
    End Sub
    Sub wdata()
        Dim dt As New DataTable
        dt.Columns.Add("VALUE1")
        dt.Columns.Add("OP")
        dt.Columns.Add("VALUE2")
        dt.Columns.Add("ANSWER")

        For i = 1 To rno
            Dim dr As DataRow = dt.NewRow
            dr(0) = d(i, 1) & "/" & d(i, 2)
            dr(1) = d(i, 3)
            dr(2) = d(i, 4) & "/" & d(i, 5)
            dr(3) = d(i, 0)
            dt.Rows.Add(dr)
        Next

        dgv.DataSource = dt
        dgv.DefaultCellStyle.Alignment = 32


    End Sub
End Class