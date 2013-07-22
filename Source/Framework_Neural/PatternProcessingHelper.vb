'------------------------------------------------------------------
' License Notice:
'------------------------------------------------------------------
' All Rights Reserved - Anoop Madhusudanan, 
' Mail: amazedsaint@gmail.com
' Website: http://amazedsaint.blogspot.com

' See my articles about BrainNet at 
' http://amazedsaint-articles.blogspot.com for details
'
' You can use this code (or part of it), for non 
' commercial and academic uses, as long as 
'   - You are keeping this notice along with it
'   - You are not making any profit out of this
'------------------------------------------------------------------

'''<summary> The class provides some basic image processing methods
'''and conversions required for neural network image processing  </summary>

Public Class PatternProcessingHelper
    '''<summary> Convert a binary string to an arraylist </summary>
    Public Function ArrayListFromPattern(ByVal pattern As String) As ArrayList
        Dim arr As ArrayList = New ArrayList()
        Dim counter As Long
        For counter = 0 To pattern.Length - 1
            arr.Add(pattern.Chars(counter).ToString)
        Next
        Return arr

    End Function

    '''<summary> Convert an arraylist by rounding each value to a pattern of 0s and 1s </summary>
    Public Function PatternFromArraylist(ByVal arr As ArrayList) As String
        Dim no As Long
        Dim str As String = ""

        For no = 0 To arr.Count - 1
            str = str & Math.Round(arr(no))

        Next

        Return str
    End Function


    '''<summary> Convert an arraylist by rounding each value to a pattern of 0s and 1s </summary>
    Public Function NumberFromArraylist(ByVal arr As ArrayList) As Long
        Return NumberFromPattern(PatternFromArraylist(arr))

    End Function


    '''<summary> Convert an arraylist to a character </summary>
    Public Function CharFromArraylist(ByVal arr As ArrayList) As String
        Return Chr(NumberFromPattern(PatternFromArraylist(arr)))
    End Function


    '''<summary>Arraylist to a character </summary>
    Public Function ArrayListFromChar(ByVal ch As String) As ArrayList
        Return ArrayListFromNumber(Asc(ch), 8)
    End Function


    '''<summary> Convert a binary string to an arraylist </summary>
    Public Function ArrayListFromNumber(ByVal value As Long, ByVal lengthOfList As Long) As ArrayList
        Dim pattern As String = PatternFromNumber(value, lengthOfList)

        Dim arr As ArrayList = New ArrayList()
        Dim counter As Long
        For counter = 0 To pattern.Length - 1
            arr.Add(pattern.Chars(counter).ToString)
        Next
        Return arr

    End Function

    '''<summary> Convert a binary string to decimal value </summary>
    Public Function NumberFromPattern(ByVal pattern As String) As Long

        Dim number As Long = 0

        Dim i, bit
        For i = 0 To pattern.Length - 1
            If pattern.Chars(pattern.Length - 1 - i) = "1" Then
                bit = 1
            Else
                bit = 0
            End If

            number = number + ((2 ^ i) * bit)

        Next

        Return number

    End Function


    '''<summary> Get an string pattern of 0s and 1s corresponding to a value. Eg. 1 
    '''will be converted to 01, 2 to 10 and so on </summary>

    Public Function PatternFromNumber(ByVal number As Integer, ByVal lengthOfPattern As Long) As String

        Dim pattern As String = ""

        Dim max As Integer = 0

        Dim i

        '''Find the maximum number of bits that can accomodate the value
        max = lengthOfPattern

        For i = 0 To max - 1
            If ((2 ^ i) And number) = (2 ^ i) Then
                pattern = "1" & pattern
            Else
                pattern = "0" & pattern
            End If

        Next

        Return pattern

    End Function
End Class
