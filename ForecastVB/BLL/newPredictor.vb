Public Class newPredictor

    Public Function predict(maand As Integer, prijs As Integer, dag As Integer, merk As Integer, subafd As Integer, soort As Integer, centrum As Integer, aard As Integer) As Boolean
        If merk <= 137.5 Then
            If soort <= 19.5 Then
                If prijs <= 1.5 Then
                    If maand <= 9.5 Then
                        If merk <= 92.0 Then
                            If merk <= 20.5 Then
                                Return False
                            ElseIf merk > 20.5 Then
                                If soort <= 16.5 Then
                                    If merk <= 27.0 Then
                                        Return False
                                    ElseIf merk > 27.0 Then
                                        If merk <= 52.5 Then
                                            If merk <= 30.5 Then
                                                Return True
                                            ElseIf merk > 30.5 Then
                                                Return False
                                            End If
                                        ElseIf merk > 52.5 Then
                                            Return True
                                        End If
                                    End If
                                ElseIf soort > 16.5 Then
                                    Return True
                                End If
                            End If
                        ElseIf merk > 92.0 Then
                            If soort <= 18.5 Then
                                If merk <= 99.5 Then
                                    If merk <= 98.0 Then
                                        If soort <= 17.0 Then
                                            If merk <= 94.5 Then
                                                Return False
                                            ElseIf merk > 94.5 Then
                                                If merk <= 96.5 Then
                                                    Return True
                                                ElseIf merk > 96.5 Then
                                                    If dag <= 1.5 Then
                                                        Return False
                                                    ElseIf dag > 1.5 Then
                                                        Return True
                                                    End If
                                                End If
                                            End If
                                        ElseIf soort > 17.0 Then
                                            Return True
                                        End If
                                    ElseIf merk > 98.0 Then
                                        Return False
                                    End If
                                ElseIf merk > 99.5 Then
                                    If soort <= 17.0 Then
                                        Return True
                                    ElseIf soort > 17.0 Then
                                        If merk <= 114.0 Then
                                            Return True
                                        ElseIf merk > 114.0 Then
                                            If merk <= 129.0 Then
                                                Return False
                                            ElseIf merk > 129.0 Then
                                                Return True
                                            End If
                                        End If
                                    End If
                                End If
                            ElseIf soort > 18.5 Then
                                Return False
                            End If
                        End If
                    ElseIf maand > 9.5 Then
                        If merk <= 56.5 Then
                            If merk <= 27.0 Then
                                Return False
                            ElseIf merk > 27.0 Then
                                If soort <= 17.0 Then
                                    Return False
                                ElseIf soort > 17.0 Then
                                    Return False
                                End If
                            End If
                        ElseIf merk > 56.5 Then
                            If soort <= 17.0 Then
                                Return True
                            ElseIf soort > 17.0 Then
                                If maand <= 11.0 Then
                                    Return False
                                ElseIf maand > 11.0 Then
                                    If merk <= 124.5 Then
                                        Return True
                                    ElseIf merk > 124.5 Then
                                        Return False
                                    End If
                                End If
                            End If
                        End If
                    End If
                ElseIf prijs > 1.5 Then
                    If soort <= 18.5 Then
                        If merk <= 101.0 Then
                            If soort <= 16.5 Then
                                If merk <= 15.0 Then
                                    Return True
                                ElseIf merk > 15.0 Then
                                    If merk <= 38.0 Then
                                        If merk <= 27.0 Then
                                            If maand <= 10.5 Then
                                                If merk <= 23.5 Then
                                                    If prijs <= 2.5 Then
                                                        Return False
                                                    ElseIf prijs > 2.5 Then
                                                        If merk <= 20.0 Then
                                                            Return True
                                                        ElseIf merk > 20.0 Then
                                                            Return False
                                                        End If
                                                    End If
                                                ElseIf merk > 23.5 Then
                                                    Return True
                                                End If
                                            ElseIf maand > 10.5 Then
                                                If maand <= 11.5 Then
                                                    Return False
                                                ElseIf maand > 11.5 Then
                                                    Return True
                                                End If
                                            End If
                                        ElseIf merk > 27.0 Then
                                            If maand <= 5.0 Then
                                                Return True
                                            ElseIf maand > 5.0 Then
                                                If maand <= 10.5 Then
                                                    If maand <= 9.5 Then
                                                        If prijs <= 3.5 Then
                                                            If merk <= 30.5 Then
                                                                Return False
                                                            ElseIf merk > 30.5 Then
                                                                Return False
                                                            End If
                                                        ElseIf prijs > 3.5 Then
                                                            Return True
                                                        End If
                                                    ElseIf maand > 9.5 Then
                                                        Return False
                                                    End If
                                                ElseIf maand > 10.5 Then
                                                    Return True
                                                End If
                                            End If
                                        End If
                                    ElseIf merk > 38.0 Then
                                        If prijs <= 2.5 Then
                                            Return True
                                        ElseIf prijs > 2.5 Then
                                            If prijs <= 3.5 Then
                                                If merk <= 98.0 Then
                                                    If merk <= 80.0 Then
                                                        Return True
                                                    ElseIf merk > 80.0 Then
                                                        If maand <= 10.0 Then
                                                            If merk <= 95.0 Then
                                                                Return False
                                                            ElseIf merk > 95.0 Then
                                                                Return False
                                                            End If
                                                        ElseIf maand > 10.0 Then
                                                            Return True
                                                        End If
                                                    End If
                                                ElseIf merk > 98.0 Then
                                                    Return True
                                                End If
                                            ElseIf prijs > 3.5 Then
                                                If prijs <= 5.5 Then
                                                    If merk <= 96.5 Then
                                                        If prijs <= 4.5 Then
                                                            Return True
                                                        ElseIf prijs > 4.5 Then
                                                            If dag <= 1.5 Then
                                                                If merk <= 88.5 Then
                                                                    Return False
                                                                ElseIf merk > 88.5 Then
                                                                    Return True
                                                                End If
                                                            ElseIf dag > 1.5 Then
                                                                Return True
                                                            End If
                                                        End If
                                                    ElseIf merk > 96.5 Then
                                                        If maand <= 10.5 Then
                                                            If prijs <= 4.5 Then
                                                                Return False
                                                            ElseIf prijs > 4.5 Then
                                                                Return False
                                                            End If
                                                        ElseIf maand > 10.5 Then
                                                            Return True
                                                        End If
                                                    End If
                                                ElseIf prijs > 5.5 Then
                                                    Return True
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            ElseIf soort > 16.5 Then
                                If merk <= 95.0 Then
                                    If dag <= 1.5 Then
                                        If merk <= 86.0 Then
                                            If merk <= 27.0 Then
                                                If prijs <= 2.5 Then
                                                    If soort <= 17.5 Then
                                                        Return True
                                                    ElseIf soort > 17.5 Then
                                                        If maand <= 9.5 Then
                                                            Return False
                                                        ElseIf maand > 9.5 Then
                                                            Return True
                                                        End If
                                                    End If
                                                ElseIf prijs > 2.5 Then
                                                    Return True
                                                End If
                                            ElseIf merk > 27.0 Then
                                                Return True
                                            End If
                                        ElseIf merk > 86.0 Then
                                            If merk <= 90.5 Then
                                                Return False
                                            ElseIf merk > 90.5 Then
                                                Return True
                                            End If
                                        End If
                                    ElseIf dag > 1.5 Then
                                        If merk <= 62.5 Then
                                            Return False
                                        ElseIf merk > 62.5 Then
                                            Return True
                                        End If
                                    End If
                                ElseIf merk > 95.0 Then
                                    If maand <= 9.5 Then
                                        If prijs <= 3.5 Then
                                            If merk <= 98.5 Then
                                                Return True
                                            ElseIf merk > 98.5 Then
                                                If prijs <= 2.5 Then
                                                    Return False
                                                ElseIf prijs > 2.5 Then
                                                    Return True
                                                End If
                                            End If
                                        ElseIf prijs > 3.5 Then
                                            Return False
                                        End If
                                    ElseIf maand > 9.5 Then
                                        Return True
                                    End If
                                End If
                            End If
                        ElseIf merk > 101.0 Then
                            If maand <= 10.5 Then
                                If merk <= 132.5 Then
                                    Return True
                                ElseIf merk > 132.5 Then
                                    If merk <= 136.5 Then
                                        If prijs <= 2.5 Then
                                            Return False
                                        ElseIf prijs > 2.5 Then
                                            Return True
                                        End If
                                    ElseIf merk > 136.5 Then
                                        Return True
                                    End If
                                End If
                            ElseIf maand > 10.5 Then
                                If merk <= 132.0 Then
                                    If soort <= 17.0 Then
                                        Return True
                                    ElseIf soort > 17.0 Then
                                        If prijs <= 3.5 Then
                                            Return True
                                        ElseIf prijs > 3.5 Then
                                            Return False
                                        End If
                                    End If
                                ElseIf merk > 132.0 Then
                                    Return False
                                End If
                            End If
                        End If
                    ElseIf soort > 18.5 Then
                        If prijs <= 4.5 Then
                            If maand <= 5.5 Then
                                Return False
                            ElseIf maand > 5.5 Then
                                If merk <= 66.0 Then
                                    Return True
                                ElseIf merk > 66.0 Then
                                    If merk <= 100.0 Then
                                        If maand <= 10.0 Then
                                            If merk <= 72.0 Then
                                                Return False
                                            ElseIf merk > 72.0 Then
                                                Return False
                                            End If
                                        ElseIf maand > 10.0 Then
                                            Return True
                                        End If
                                    ElseIf merk > 100.0 Then
                                        If maand <= 10.5 Then
                                            If prijs <= 3.5 Then
                                                If merk <= 127.5 Then
                                                    Return False
                                                ElseIf merk > 127.5 Then
                                                    Return True
                                                End If
                                            ElseIf prijs > 3.5 Then
                                                Return False
                                            End If
                                        ElseIf maand > 10.5 Then
                                            Return True
                                        End If
                                    End If
                                End If
                            End If
                        ElseIf prijs > 4.5 Then
                            Return False
                        End If
                    End If
                End If
            ElseIf soort > 19.5 Then
                If prijs <= 2.5 Then
                    If merk <= 103.0 Then
                        If prijs <= 1.5 Then
                            Return True
                        ElseIf prijs > 1.5 Then
                            If maand <= 10.5 Then
                                If soort <= 20.5 Then
                                    If maand <= 9.5 Then
                                        Return False
                                    ElseIf maand > 9.5 Then
                                        Return False
                                    End If
                                ElseIf soort > 20.5 Then
                                    Return True
                                End If
                            ElseIf maand > 10.5 Then
                                Return True
                            End If
                        End If
                    ElseIf merk > 103.0 Then
                        If soort <= 20.5 Then
                            Return True
                        ElseIf soort > 20.5 Then
                            Return False
                        End If
                    End If
                ElseIf prijs > 2.5 Then
                    Return True
                End If
            End If
        ElseIf merk > 137.5 Then
            If merk <= 173.5 Then
                If merk <= 167.5 Then
                    If prijs <= 2.5 Then
                        If soort <= 16.5 Then
                            If merk <= 138.5 Then
                                If prijs <= 1.5 Then
                                    Return True
                                ElseIf prijs > 1.5 Then
                                    Return False
                                End If
                            ElseIf merk > 138.5 Then
                                If prijs <= 1.5 Then
                                    If maand <= 10.5 Then
                                        If merk <= 149.5 Then
                                            Return True
                                        ElseIf merk > 149.5 Then
                                            If maand <= 9.5 Then
                                                Return False
                                            ElseIf maand > 9.5 Then
                                                Return True
                                            End If
                                        End If
                                    ElseIf maand > 10.5 Then
                                        If dag <= 1.5 Then
                                            Return False
                                        ElseIf dag > 1.5 Then
                                            Return True
                                        End If
                                    End If
                                ElseIf prijs > 1.5 Then
                                    Return True
                                End If
                            End If
                        ElseIf soort > 16.5 Then
                            If soort <= 19.5 Then
                                If soort <= 18.5 Then
                                    If prijs <= 1.5 Then
                                        If maand <= 9.5 Then
                                            If merk <= 148.5 Then
                                                If merk <= 138.5 Then
                                                    Return False
                                                ElseIf merk > 138.5 Then
                                                    If merk <= 140.5 Then
                                                        Return False
                                                    ElseIf merk > 140.5 Then
                                                        Return False
                                                    End If
                                                End If
                                            ElseIf merk > 148.5 Then
                                                If merk <= 157.5 Then
                                                    Return False
                                                ElseIf merk > 157.5 Then
                                                    Return True
                                                End If
                                            End If
                                        ElseIf maand > 9.5 Then
                                            If maand <= 11.5 Then
                                                Return False
                                            ElseIf maand > 11.5 Then
                                                Return False
                                            End If
                                        End If
                                    ElseIf prijs > 1.5 Then
                                        If merk <= 151.0 Then
                                            Return True
                                        ElseIf merk > 151.0 Then
                                            If merk <= 155.5 Then
                                                If soort <= 17.5 Then
                                                    Return False
                                                ElseIf soort > 17.5 Then
                                                    Return False
                                                End If
                                            ElseIf merk > 155.5 Then
                                                Return True
                                            End If
                                        End If
                                    End If
                                ElseIf soort > 18.5 Then
                                    If merk <= 144.5 Then
                                        If maand <= 9.5 Then
                                            If prijs <= 1.5 Then
                                                Return False
                                            ElseIf prijs > 1.5 Then
                                                Return False
                                            End If
                                        ElseIf maand > 9.5 Then
                                            Return True
                                        End If
                                    ElseIf merk > 144.5 Then
                                        If merk <= 153.5 Then
                                            Return False
                                        ElseIf merk > 153.5 Then
                                            Return True
                                        End If
                                    End If
                                End If
                            ElseIf soort > 19.5 Then
                                Return True
                            End If
                        End If
                    ElseIf prijs > 2.5 Then
                        If soort <= 19.5 Then
                            If maand <= 11.5 Then
                                If soort <= 17.5 Then
                                    If merk <= 158.0 Then
                                        If prijs <= 4.5 Then
                                            If maand <= 9.5 Then
                                                If merk <= 138.5 Then
                                                    Return False
                                                ElseIf merk > 138.5 Then
                                                    If merk <= 152.0 Then
                                                        If soort <= 16.5 Then
                                                            Return True
                                                        ElseIf soort > 16.5 Then
                                                            If prijs <= 3.5 Then
                                                                Return True
                                                            ElseIf prijs > 3.5 Then
                                                                Return False
                                                            End If
                                                        End If
                                                    ElseIf merk > 152.0 Then
                                                        If prijs <= 3.5 Then
                                                            Return False
                                                        ElseIf prijs > 3.5 Then
                                                            Return False
                                                        End If
                                                    End If
                                                End If
                                            ElseIf maand > 9.5 Then
                                                If prijs <= 3.5 Then
                                                    If soort <= 16.5 Then
                                                        Return False
                                                    ElseIf soort > 16.5 Then
                                                        Return True
                                                    End If
                                                ElseIf prijs > 3.5 Then
                                                    If dag <= 2.5 Then
                                                        Return False
                                                    ElseIf dag > 2.5 Then
                                                        If maand <= 10.5 Then
                                                            Return False
                                                        ElseIf maand > 10.5 Then
                                                            Return False
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        ElseIf prijs > 4.5 Then
                                            Return True
                                        End If
                                    ElseIf merk > 158.0 Then
                                        If dag <= 1.5 Then
                                            Return False
                                        ElseIf dag > 1.5 Then
                                            Return True
                                        End If
                                    End If
                                ElseIf soort > 17.5 Then
                                    If maand <= 9.5 Then
                                        If merk <= 150.5 Then
                                            If prijs <= 3.5 Then
                                                Return False
                                            ElseIf prijs > 3.5 Then
                                                If prijs <= 5.5 Then
                                                    If soort <= 18.5 Then
                                                        If merk <= 138.5 Then
                                                            Return False
                                                        ElseIf merk > 138.5 Then
                                                            Return False
                                                        End If
                                                    ElseIf soort > 18.5 Then
                                                        Return True
                                                    End If
                                                ElseIf prijs > 5.5 Then
                                                    Return True
                                                End If
                                            End If
                                        ElseIf merk > 150.5 Then
                                            If merk <= 157.5 Then
                                                If maand <= 6.5 Then
                                                    Return True
                                                ElseIf maand > 6.5 Then
                                                    If merk <= 154.5 Then
                                                        Return False
                                                    ElseIf merk > 154.5 Then
                                                        If prijs <= 4.5 Then
                                                            If soort <= 18.5 Then
                                                                If prijs <= 3.5 Then
                                                                    Return False
                                                                ElseIf prijs > 3.5 Then
                                                                    Return False
                                                                End If
                                                            ElseIf soort > 18.5 Then
                                                                Return False
                                                            End If
                                                        ElseIf prijs > 4.5 Then
                                                            Return True
                                                        End If
                                                    End If
                                                End If
                                            ElseIf merk > 157.5 Then
                                                Return True
                                            End If
                                        End If
                                    ElseIf maand > 9.5 Then
                                        If merk <= 144.5 Then
                                            If prijs <= 3.5 Then
                                                If soort <= 18.5 Then
                                                    If merk <= 140.5 Then
                                                        Return False
                                                    ElseIf merk > 140.5 Then
                                                        Return False
                                                    End If
                                                ElseIf soort > 18.5 Then
                                                    Return True
                                                End If
                                            ElseIf prijs > 3.5 Then
                                                If prijs <= 4.5 Then
                                                    Return True
                                                ElseIf prijs > 4.5 Then
                                                    If merk <= 140.5 Then
                                                        Return False
                                                    ElseIf merk > 140.5 Then
                                                        If soort <= 18.5 Then
                                                            Return True
                                                        ElseIf soort > 18.5 Then
                                                            If maand <= 10.5 Then
                                                                Return False
                                                            ElseIf maand > 10.5 Then
                                                                Return False
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        ElseIf merk > 144.5 Then
                                            Return True
                                        End If
                                    End If
                                End If
                            ElseIf maand > 11.5 Then
                                If prijs <= 4.5 Then
                                    Return True
                                ElseIf prijs > 4.5 Then
                                    Return False
                                End If
                            End If
                        ElseIf soort > 19.5 Then
                            If soort <= 20.5 Then
                                If merk <= 143.5 Then
                                    If maand <= 10.0 Then
                                        Return False
                                    ElseIf maand > 10.0 Then
                                        Return True
                                    End If
                                ElseIf merk > 143.5 Then
                                    If merk <= 151.5 Then
                                        Return True
                                    ElseIf merk > 151.5 Then
                                        If merk <= 155.5 Then
                                            Return False
                                        ElseIf merk > 155.5 Then
                                            Return True
                                        End If
                                    End If
                                End If
                            ElseIf soort > 20.5 Then
                                Return False
                            End If
                        End If
                    End If
                ElseIf merk > 167.5 Then
                    If maand <= 11.5 Then
                        If maand <= 9.5 Then
                            If maand <= 8.5 Then
                                Return True
                            ElseIf maand > 8.5 Then
                                If soort <= 17.0 Then
                                    If prijs <= 1.5 Then
                                        If merk <= 170.5 Then
                                            Return True
                                        ElseIf merk > 170.5 Then
                                            Return False
                                        End If
                                    ElseIf prijs > 1.5 Then
                                        If prijs <= 2.5 Then
                                            If merk <= 170.5 Then
                                                Return False
                                            ElseIf merk > 170.5 Then
                                                Return False
                                            End If
                                        ElseIf prijs > 2.5 Then
                                            If merk <= 170.5 Then
                                                If prijs <= 4.5 Then
                                                    If prijs <= 3.5 Then
                                                        Return False
                                                    ElseIf prijs > 3.5 Then
                                                        Return False
                                                    End If
                                                ElseIf prijs > 4.5 Then
                                                    Return False
                                                End If
                                            ElseIf merk > 170.5 Then
                                                Return True
                                            End If
                                        End If
                                    End If
                                ElseIf soort > 17.0 Then
                                    If dag <= 1.5 Then
                                        If merk <= 168.5 Then
                                            If prijs <= 4.5 Then
                                                If prijs <= 3.5 Then
                                                    If prijs <= 1.5 Then
                                                        If soort <= 19.0 Then
                                                            Return False
                                                        ElseIf soort > 19.0 Then
                                                            Return False
                                                        End If
                                                    ElseIf prijs > 1.5 Then
                                                        If prijs <= 2.5 Then
                                                            If soort <= 19.0 Then
                                                                Return False
                                                            ElseIf soort > 19.0 Then
                                                                Return False
                                                            End If
                                                        ElseIf prijs > 2.5 Then
                                                            If soort <= 19.0 Then
                                                                Return False
                                                            ElseIf soort > 19.0 Then
                                                                Return False
                                                            End If
                                                        End If
                                                    End If
                                                ElseIf prijs > 3.5 Then
                                                    If soort <= 19.0 Then
                                                        Return False
                                                    ElseIf soort > 19.0 Then
                                                        Return False
                                                    End If
                                                End If
                                            ElseIf prijs > 4.5 Then
                                                If soort <= 19.0 Then
                                                    Return False
                                                ElseIf soort > 19.0 Then
                                                    Return True
                                                End If
                                            End If
                                        ElseIf merk > 168.5 Then
                                            If prijs <= 1.5 Then
                                                Return True
                                            ElseIf prijs > 1.5 Then
                                                If prijs <= 2.5 Then
                                                    Return False
                                                ElseIf prijs > 2.5 Then
                                                    If soort <= 19.5 Then
                                                        If prijs <= 5.0 Then
                                                            Return True
                                                        ElseIf prijs > 5.0 Then
                                                            Return False
                                                        End If
                                                    ElseIf soort > 19.5 Then
                                                        Return False
                                                    End If
                                                End If
                                            End If
                                        End If
                                    ElseIf dag > 1.5 Then
                                        Return True
                                    End If
                                End If
                            End If
                        ElseIf maand > 9.5 Then
                            If prijs <= 3.5 Then
                                If soort <= 17.0 Then
                                    Return False
                                ElseIf soort > 17.0 Then
                                    If prijs <= 1.5 Then
                                        Return False
                                    ElseIf prijs > 1.5 Then
                                        If maand <= 10.5 Then
                                            Return True
                                        ElseIf maand > 10.5 Then
                                            If soort <= 19.0 Then
                                                Return False
                                            ElseIf soort > 19.0 Then
                                                Return True
                                            End If
                                        End If
                                    End If
                                End If
                            ElseIf prijs > 3.5 Then
                                If prijs <= 4.5 Then
                                    Return False
                                ElseIf prijs > 4.5 Then
                                    Return False
                                End If
                            End If
                        End If
                    ElseIf maand > 11.5 Then
                        If prijs <= 1.5 Then
                            If soort <= 17.0 Then
                                Return True
                            ElseIf soort > 17.0 Then
                                If soort <= 19.0 Then
                                    Return False
                                ElseIf soort > 19.0 Then
                                    Return True
                                End If
                            End If
                        ElseIf prijs > 1.5 Then
                            Return True
                        End If
                    End If
                End If
            ElseIf merk > 173.5 Then
                If merk <= 242.5 Then
                    If merk <= 190.0 Then
                        If merk <= 188.0 Then
                            If prijs <= 1.5 Then
                                If merk <= 177.5 Then
                                    If maand <= 9.5 Then
                                        If soort <= 18.0 Then
                                            Return False
                                        ElseIf soort > 18.0 Then
                                            Return False
                                        End If
                                    ElseIf maand > 9.5 Then
                                        If maand <= 11.0 Then
                                            Return False
                                        ElseIf maand > 11.0 Then
                                            Return False
                                        End If
                                    End If
                                ElseIf merk > 177.5 Then
                                    If merk <= 186.5 Then
                                        Return True
                                    ElseIf merk > 186.5 Then
                                        If soort <= 18.5 Then
                                            Return False
                                        ElseIf soort > 18.5 Then
                                            Return True
                                        End If
                                    End If
                                End If
                            ElseIf prijs > 1.5 Then
                                If merk <= 177.5 Then
                                    If soort <= 19.0 Then
                                        If soort <= 17.0 Then
                                            If prijs <= 4.5 Then
                                                If maand <= 10.0 Then
                                                    If prijs <= 3.5 Then
                                                        If prijs <= 2.5 Then
                                                            Return False
                                                        ElseIf prijs > 2.5 Then
                                                            Return False
                                                        End If
                                                    ElseIf prijs > 3.5 Then
                                                        Return True
                                                    End If
                                                ElseIf maand > 10.0 Then
                                                    If prijs <= 3.5 Then
                                                        Return True
                                                    ElseIf prijs > 3.5 Then
                                                        If merk <= 175.5 Then
                                                            Return True
                                                        ElseIf merk > 175.5 Then
                                                            Return False
                                                        End If
                                                    End If
                                                End If
                                            ElseIf prijs > 4.5 Then
                                                If maand <= 10.0 Then
                                                    If prijs <= 5.5 Then
                                                        Return False
                                                    ElseIf prijs > 5.5 Then
                                                        Return False
                                                    End If
                                                ElseIf maand > 10.0 Then
                                                    Return True
                                                End If
                                            End If
                                        ElseIf soort > 17.0 Then
                                            Return False
                                        End If
                                    ElseIf soort > 19.0 Then
                                        If prijs <= 2.5 Then
                                            If maand <= 10.0 Then
                                                Return False
                                            ElseIf maand > 10.0 Then
                                                Return True
                                            End If
                                        ElseIf prijs > 2.5 Then
                                            Return True
                                        End If
                                    End If
                                ElseIf merk > 177.5 Then
                                    Return True
                                End If
                            End If
                        ElseIf merk > 188.0 Then
                            If soort <= 17.0 Then
                                If maand <= 11.5 Then
                                    If maand <= 9.5 Then
                                        If prijs <= 3.5 Then
                                            If maand <= 6.0 Then
                                                Return False
                                            ElseIf maand > 6.0 Then
                                                If prijs <= 1.5 Then
                                                    Return False
                                                ElseIf prijs > 1.5 Then
                                                    Return True
                                                End If
                                            End If
                                        ElseIf prijs > 3.5 Then
                                            Return False
                                        End If
                                    ElseIf maand > 9.5 Then
                                        Return False
                                    End If
                                ElseIf maand > 11.5 Then
                                    If prijs <= 2.5 Then
                                        Return False
                                    ElseIf prijs > 2.5 Then
                                        Return True
                                    End If
                                End If
                            ElseIf soort > 17.0 Then
                                If maand <= 3.5 Then
                                    Return False
                                ElseIf maand > 3.5 Then
                                    If maand <= 11.5 Then
                                        If maand <= 7.5 Then
                                            Return True
                                        ElseIf maand > 7.5 Then
                                            If dag <= 1.5 Then
                                                If soort <= 19.0 Then
                                                    If prijs <= 3.5 Then
                                                        If maand <= 10.0 Then
                                                            If prijs <= 2.5 Then
                                                                Return True
                                                            ElseIf prijs > 2.5 Then
                                                                Return False
                                                            End If
                                                        ElseIf maand > 10.0 Then
                                                            Return False
                                                        End If
                                                    ElseIf prijs > 3.5 Then
                                                        Return True
                                                    End If
                                                ElseIf soort > 19.0 Then
                                                    If prijs <= 3.5 Then
                                                        Return True
                                                    ElseIf prijs > 3.5 Then
                                                        Return False
                                                    End If
                                                End If
                                            ElseIf dag > 1.5 Then
                                                Return True
                                            End If
                                        End If
                                    ElseIf maand > 11.5 Then
                                        Return False
                                    End If
                                End If
                            End If
                        End If
                    ElseIf merk > 190.0 Then
                        If soort <= 18.5 Then
                            If merk <= 211.5 Then
                                If maand <= 9.5 Then
                                    If soort <= 16.5 Then
                                        If merk <= 193.0 Then
                                            If prijs <= 2.5 Then
                                                Return False
                                            ElseIf prijs > 2.5 Then
                                                Return True
                                            End If
                                        ElseIf merk > 193.0 Then
                                            Return True
                                        End If
                                    ElseIf soort > 16.5 Then
                                        If soort <= 17.5 Then
                                            Return False
                                        ElseIf soort > 17.5 Then
                                            If maand <= 1.5 Then
                                                Return True
                                            ElseIf maand > 1.5 Then
                                                If maand <= 2.5 Then
                                                    If merk <= 204.5 Then
                                                        Return True
                                                    ElseIf merk > 204.5 Then
                                                        Return False
                                                    End If
                                                ElseIf maand > 2.5 Then
                                                    If prijs <= 1.5 Then
                                                        Return True
                                                    ElseIf prijs > 1.5 Then
                                                        If maand <= 7.0 Then
                                                            Return True
                                                        ElseIf maand > 7.0 Then
                                                            If merk <= 201.5 Then
                                                                If prijs <= 3.0 Then
                                                                    Return False
                                                                ElseIf prijs > 3.0 Then
                                                                    Return False
                                                                End If
                                                            ElseIf merk > 201.5 Then
                                                                If prijs <= 2.5 Then
                                                                    Return True
                                                                ElseIf prijs > 2.5 Then
                                                                    If prijs <= 3.5 Then
                                                                        Return False
                                                                    ElseIf prijs > 3.5 Then
                                                                        Return True
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                ElseIf maand > 9.5 Then
                                    Return True
                                End If
                            ElseIf merk > 211.5 Then
                                If merk <= 214.5 Then
                                    If prijs <= 1.5 Then
                                        Return False
                                    ElseIf prijs > 1.5 Then
                                        Return True
                                    End If
                                ElseIf merk > 214.5 Then
                                    If soort <= 17.5 Then
                                        If merk <= 230.5 Then
                                            If maand <= 6.5 Then
                                                Return True
                                            ElseIf maand > 6.5 Then
                                                If maand <= 10.5 Then
                                                    If prijs <= 3.0 Then
                                                        If maand <= 9.5 Then
                                                            If soort <= 16.5 Then
                                                                If prijs <= 1.5 Then
                                                                    Return False
                                                                ElseIf prijs > 1.5 Then
                                                                    Return False
                                                                End If
                                                            ElseIf soort > 16.5 Then
                                                                Return True
                                                            End If
                                                        ElseIf maand > 9.5 Then
                                                            Return False
                                                        End If
                                                    ElseIf prijs > 3.0 Then
                                                        Return True
                                                    End If
                                                ElseIf maand > 10.5 Then
                                                    Return True
                                                End If
                                            End If
                                        ElseIf merk > 230.5 Then
                                            If maand <= 6.5 Then
                                                If prijs <= 1.5 Then
                                                    Return True
                                                ElseIf prijs > 1.5 Then
                                                    Return False
                                                End If
                                            ElseIf maand > 6.5 Then
                                                Return True
                                            End If
                                        End If
                                    ElseIf soort > 17.5 Then
                                        If prijs <= 1.5 Then
                                            If maand <= 10.0 Then
                                                Return True
                                            ElseIf maand > 10.0 Then
                                                Return False
                                            End If
                                        ElseIf prijs > 1.5 Then
                                            If maand <= 10.5 Then
                                                If prijs <= 2.5 Then
                                                    If merk <= 236.5 Then
                                                        Return False
                                                    ElseIf merk > 236.5 Then
                                                        Return False
                                                    End If
                                                ElseIf prijs > 2.5 Then
                                                    Return True
                                                End If
                                            ElseIf maand > 10.5 Then
                                                If prijs <= 3.5 Then
                                                    Return True
                                                ElseIf prijs > 3.5 Then
                                                    If dag <= 1.5 Then
                                                        Return False
                                                    ElseIf dag > 1.5 Then
                                                        Return True
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        ElseIf soort > 18.5 Then
                            If dag <= 2.5 Then
                                If merk <= 228.5 Then
                                    If maand <= 5.5 Then
                                        Return True
                                    ElseIf maand > 5.5 Then
                                        If maand <= 10.5 Then
                                            If maand <= 9.5 Then
                                                If merk <= 211.0 Then
                                                    If prijs <= 1.5 Then
                                                        Return False
                                                    ElseIf prijs > 1.5 Then
                                                        Return False
                                                    End If
                                                ElseIf merk > 211.0 Then
                                                    If prijs <= 1.5 Then
                                                        Return True
                                                    ElseIf prijs > 1.5 Then
                                                        If merk <= 221.0 Then
                                                            If prijs <= 2.5 Then
                                                                Return False
                                                            ElseIf prijs > 2.5 Then
                                                                Return True
                                                            End If
                                                        ElseIf merk > 221.0 Then
                                                            If merk <= 223.0 Then
                                                                Return False
                                                            ElseIf merk > 223.0 Then
                                                                Return False
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            ElseIf maand > 9.5 Then
                                                Return False
                                            End If
                                        ElseIf maand > 10.5 Then
                                            Return True
                                        End If
                                    End If
                                ElseIf merk > 228.5 Then
                                    If prijs <= 5.0 Then
                                        If maand <= 11.5 Then
                                            If maand <= 9.5 Then
                                                If prijs <= 3.5 Then
                                                    If prijs <= 2.5 Then
                                                        If prijs <= 1.5 Then
                                                            Return False
                                                        ElseIf prijs > 1.5 Then
                                                            Return False
                                                        End If
                                                    ElseIf prijs > 2.5 Then
                                                        Return True
                                                    End If
                                                ElseIf prijs > 3.5 Then
                                                    If dag <= 1.5 Then
                                                        Return False
                                                    ElseIf dag > 1.5 Then
                                                        Return True
                                                    End If
                                                End If
                                            ElseIf maand > 9.5 Then
                                                Return True
                                            End If
                                        ElseIf maand > 11.5 Then
                                            If prijs <= 2.5 Then
                                                If prijs <= 1.5 Then
                                                    If merk <= 234.5 Then
                                                        Return False
                                                    ElseIf merk > 234.5 Then
                                                        Return True
                                                    End If
                                                ElseIf prijs > 1.5 Then
                                                    Return True
                                                End If
                                            ElseIf prijs > 2.5 Then
                                                Return False
                                            End If
                                        End If
                                    ElseIf prijs > 5.0 Then
                                        Return False
                                    End If
                                End If
                            ElseIf dag > 2.5 Then
                                If maand <= 9.5 Then
                                    Return True
                                ElseIf maand > 9.5 Then
                                    If maand <= 10.5 Then
                                        Return False
                                    ElseIf maand > 10.5 Then
                                        Return False
                                    End If
                                End If
                            End If
                        End If
                    End If
                ElseIf merk > 242.5 Then
                    If soort <= 19.0 Then
                        If soort <= 17.5 Then
                            If maand <= 10.5 Then
                                If merk <= 246.5 Then
                                    If prijs <= 3.5 Then
                                        If prijs <= 1.5 Then
                                            Return False
                                        ElseIf prijs > 1.5 Then
                                            Return True
                                        End If
                                    ElseIf prijs > 3.5 Then
                                        If maand <= 9.5 Then
                                            Return False
                                        ElseIf maand > 9.5 Then
                                            Return True
                                        End If
                                    End If
                                ElseIf merk > 246.5 Then
                                    Return True
                                End If
                            ElseIf maand > 10.5 Then
                                Return False
                            End If
                        ElseIf soort > 17.5 Then
                            If prijs <= 2.5 Then
                                If prijs <= 1.5 Then
                                    If maand <= 6.5 Then
                                        Return False
                                    ElseIf maand > 6.5 Then
                                        Return False
                                    End If
                                ElseIf prijs > 1.5 Then
                                    If maand <= 10.5 Then
                                        Return False
                                    ElseIf maand > 10.5 Then
                                        Return False
                                    End If
                                End If
                            ElseIf prijs > 2.5 Then
                                If prijs <= 3.5 Then
                                    Return True
                                ElseIf prijs > 3.5 Then
                                    If maand <= 9.5 Then
                                        Return True
                                    ElseIf maand > 9.5 Then
                                        Return False
                                    End If
                                End If
                            End If
                        End If
                    ElseIf soort > 19.0 Then
                        Return True
                    End If
                End If
            End If
        End If

        Return Nothing

    End Function

End Class