Public Class newPredictor
    Public Function predict(maand As Integer, prijs As Integer, dag As Integer, merk As Integer, subafd As Integer, soort As Integer, centrum As Integer, aard As Integer) As Boolean
        If subafd <= 228.5 Then
            If subafd <= 122.5 Then
                If aard <= 7.0 Then
                    If maand <= 6.5 Then
                        Return False
                    ElseIf maand > 6.5 Then
                        If maand <= 11.0 Then
                            If centrum <= 17.0 Then
                                If dag <= 2.5 Then
                                    Return True
                                ElseIf dag > 2.5 Then
                                    Return False
                                End If
                            ElseIf centrum > 17.0 Then
                                If prijs <= 530.58502197265625 Then
                                    Return True
                                ElseIf prijs > 530.58502197265625 Then
                                    If prijs <= 894.19000244140625 Then
                                        Return False
                                    ElseIf prijs > 894.19000244140625 Then
                                        Return True
                                    End If
                                End If
                            End If
                        ElseIf maand > 11.0 Then
                            Return False
                        End If
                    End If
                ElseIf aard > 7.0 Then
                    Return True
                End If
            ElseIf subafd > 122.5 Then
                If aard <= 7.0 Then
                    If prijs <= 380.54501342773438 Then
                        Return True
                    ElseIf prijs > 380.54501342773438 Then
                        If prijs <= 399.29998779296875 Then
                            If dag <= 3.0 Then
                                Return False
                            ElseIf dag > 3.0 Then
                                Return True
                            End If
                        ElseIf prijs > 399.29998779296875 Then
                            If dag <= 5.5 Then
                                Return True
                            ElseIf dag > 5.5 Then
                                If prijs <= 448.30499267578125 Then
                                    Return True
                                ElseIf prijs > 448.30499267578125 Then
                                    If prijs <= 474.92498779296875 Then
                                        Return False
                                    ElseIf prijs > 474.92498779296875 Then
                                        Return True
                                    End If
                                End If
                            End If
                        End If
                    End If
                ElseIf aard > 7.0 Then
                    If maand <= 8.5 Then
                        Return False
                    ElseIf maand > 8.5 Then
                        Return True
                    End If
                End If
            End If
        ElseIf subafd > 228.5 Then
            If prijs <= 59.895000457763672 Then
                Return False
            ElseIf prijs > 59.895000457763672 Then
                If dag <= 5.0 Then
                    If dag <= 2.5 Then
                        If prijs <= 139.14999389648438 Then
                            Return False
                        ElseIf prijs > 139.14999389648438 Then
                            If prijs <= 224.45498657226563 Then
                                Return True
                            ElseIf prijs > 224.45498657226563 Then
                                If prijs <= 321.8599853515625 Then
                                    Return False
                                ElseIf prijs > 321.8599853515625 Then
                                    If prijs <= 906.89501953125 Then
                                        Return True
                                    ElseIf prijs > 906.89501953125 Then
                                        Return False
                                    End If
                                End If
                            End If
                        End If
                    ElseIf dag > 2.5 Then
                        Return True
                    End If
                ElseIf dag > 5.0 Then
                    If prijs <= 321.8599853515625 Then
                        Return True
                    ElseIf prijs > 321.8599853515625 Then
                        Return False
                    End If
                End If
            End If
        End If

    End Function

End Class