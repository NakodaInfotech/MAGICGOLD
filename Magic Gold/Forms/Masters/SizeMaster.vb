
Imports System.Data.OleDb

Public Class SizeMaster

    Public FRMSTRING As String
    Public TempName As String        'Used for tempname while edit mode
    Public TempID As Integer         'Used for tempname while edit mode
    Public edit As Boolean           'Used for edit

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            If Not VALIDATENAME() Then e.Cancel = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function VALIDATENAME() As Boolean
        Try
            Dim BLN As Boolean = True
            If (edit = False) Or (edit = True And LCase(TempName) <> LCase(txtname.Text.Trim)) Then
                EP.Clear()
                duplicate = False
                tempcondition = ""
                If FRMSTRING = "SHAPE" Then
                    duplication("SHAPEMASTER", "SHAPE_NAME", txtname.Text.Trim, tempcondition)
                ElseIf FRMSTRING = "SIZE" Then
                    duplication("SIZEMASTER", "SIZE_NAME", txtname.Text.Trim, tempcondition)
                ElseIf FRMSTRING = "COLOR" Then
                    duplication("COLORMASTER", "COLOR_NAME", txtname.Text.Trim, tempcondition)
                ElseIf FRMSTRING = "DEPARTMENT" Then
                    DUPLICATIONOG("DEPARTMENTMASTER", "DEPARTMENT_NAME", txtname.Text.Trim, tempcondition)
                End If
                If duplicate = True Then EP.SetError(txtname, "Duplicate Name")
                BLN = Not duplicate
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            For i = 0 To 100
                tempcol(i) = ""
                tempval(i) = ""
            Next

            If FRMSTRING = "SHAPE" Then

                tempcol(0) = "SHAPE_name"
                tempcol(1) = "SHAPE_userid"

                tempval(0) = "'" & txtname.Text.Trim & "'"
                tempval(1) = tempuserid

                If edit = False Then
                    insert("SHAPEMASTER", tempcol, tempval)
                    MessageBox.Show("Shape Added")
                ElseIf edit = True Then
                    tempcondition = " where SHAPE_name = '" + TempName + "'"
                    modify("SHAPEMASTER", tempcol, tempval, tempcondition)
                    MessageBox.Show("Shape Updated")
                End If

            ElseIf FRMSTRING = "SIZE" Then

                tempcol(0) = "SIZE_name"
                tempcol(1) = "SIZE_userid"

                tempval(0) = "'" & txtname.Text.Trim & "'"
                tempval(1) = tempuserid

                If edit = False Then
                    insert("SIZEmaster", tempcol, tempval)
                    MessageBox.Show("Size Added")
                ElseIf edit = True Then
                    tempcondition = " where SIZE_name = '" + TempName + "'"
                    modify("SIZEmaster", tempcol, tempval, tempcondition)
                    MessageBox.Show("Size Updated")
                End If

            ElseIf FRMSTRING = "COLOR" Then

                tempcol(0) = "Color_name"
                tempcol(1) = "Color_userid"

                tempval(0) = "'" & txtname.Text.Trim & "'"
                tempval(1) = tempuserid

                If edit = False Then
                    insert("Colormaster", tempcol, tempval)
                    MessageBox.Show("Color Added")
                ElseIf edit = True Then
                    tempcondition = " where Color_name = '" + TempName + "'"
                    modify("Colormaster", tempcol, tempval, tempcondition)
                    MessageBox.Show("Color Updated")
                End If

            ElseIf FRMSTRING = "DEPARTMENT" Then

                tempcol(0) = "DEPARTMENT_NAME"
                tempcol(1) = "DEPARTMENT_USERID"

                tempval(0) = "'" & txtname.Text.Trim & "'"
                tempval(1) = tempuserid

                If edit = False Then
                    'ADD IN MAIN DATABASE ALSO
                    'CODE DONE BY GULKIT
                    insert("DEPARTMENTMASTER", tempcol, tempval)
                    INSERTOG("DEPARTMENTMASTER", tempcol, tempval)
                    MessageBox.Show("Department Added")
                ElseIf edit = True Then

                    tempcondition = " where DEPARTMENT_NAME = '" + TempName + "'"

                    'UPDATE IN MAIN DATABASE ALSO
                    'CODE DONE BY GULKIT
                    modify("DEPARTMENTMASTER", tempcol, tempval, tempcondition)
                    MODIFYOG("DEPARTMENTMASTER", tempcol, tempval, tempcondition)
                    MessageBox.Show("Department Updated")
                End If

            End If

            clear()
            txtname.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If ISMASTER = False Then bln = False

        If txtname.Text.Trim.Length = 0 Then
            EP.SetError(txtname, "Fill Name")
            bln = False
        End If

        If Not VALIDATENAME() Then
            EP.SetError(txtname, "Name Already Exists")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()
        txtname.Clear()
        txtremarks.Clear()
        edit = False
    End Sub

    Private Sub SizeMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SizeMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If FRMSTRING = "SHAPE" Then

                Me.Text = "Shape Master"
                lblgroup.Text = "Shape"
                lbl.Text = "Enter Shape" & vbCrLf & "(e.g. Round, Square,..,etc.)"
                If edit = True Then
                    cmd = New OleDbCommand("select shape_name AS NAME from shapemaster where shape_name = '" & TempName & "'", conn)
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    dr = cmd.ExecuteReader
                    If dr.HasRows = True Then
                        dr.Read()
                        txtname.Text = dr("NAME")
                    End If
                End If

            ElseIf FRMSTRING = "SIZE" Then

                Me.Text = "Size Master"
                lblgroup.Text = "Size"
                lbl.Text = "Enter Size" & vbCrLf & "(e.g. -0.3 To 1.25, 1.25 To 2.05,..,etc.)"
                If edit = True Then
                    cmd = New OleDbCommand("select Size_name AS NAME from Sizemaster where Size_name = '" & TempName & "'", conn)
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    dr = cmd.ExecuteReader
                    If dr.HasRows = True Then
                        dr.Read()
                        txtname.Text = dr("NAME")
                    End If
                End If

            ElseIf FRMSTRING = "COLOR" Then

                Me.Text = "Color Master"
                lblgroup.Text = "Color"
                lbl.Text = "Enter Color" & vbCrLf & "(e.g. Red, Green,..,etc.)"
                If edit = True Then
                    cmd = New OleDbCommand("select COLOR_name AS NAME from Colormaster where Color_name = '" & TempName & "'", conn)
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    dr = cmd.ExecuteReader
                    If dr.HasRows = True Then
                        dr.Read()
                        txtname.Text = dr("NAME")
                    End If
                End If

            ElseIf FRMSTRING = "DEPARTMENT" Then

                Me.Text = "Department Master"
                lblgroup.Text = "Department"
                lbl.Text = "Enter Department" & vbCrLf & "(e.g. Red, Green,..,etc.)"
                If edit = True Then
                    cmd = New OleDbCommand("select Department_name AS NAME from Departmentmaster where Department_name = '" & TempName & "'", OGCONN)
                    If OGCONN.State = ConnectionState.Open Then OGCONN.Close()
                    OGCONN.Open()
                    dr = cmd.ExecuteReader
                    If dr.HasRows = True Then
                        dr.Read()
                        txtname.Text = dr("NAME")
                    End If
                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If edit = False Then
                MsgBox("Delete Allowed in Edit Mode Only", MsgBoxStyle.Critical)
                Exit Sub
            End If
            'If FRMSTRING = "BOOKEDBY" Then
            '    Dim TEMPMSG As Integer = MsgBox("Wish to Delete " & txtname.Text.Trim & "?", MsgBoxStyle.YesNo)
            '    If TEMPMSG = vbYes Then
            '        Dim OBJBOOKEDBY As New ClsBookedByMaster
            '        Dim ALPARAVAL As New ArrayList

            '        ALPARAVAL.Add(txtname.Text.Trim)
            '        ALPARAVAL.Add(CmpId)
            '        ALPARAVAL.Add(Locationid)
            '        ALPARAVAL.Add(YearId)

            '        OBJBOOKEDBY.alParaval = ALPARAVAL
            '        Dim DT As DataTable = OBJBOOKEDBY.DELETE
            '        MsgBox(DT.Rows(0).Item(0))
            '        clear()
            '    End If
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SizeMaster_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ISMASTER = False Then
                cmdok.Enabled = False
                CMDDELETE.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class