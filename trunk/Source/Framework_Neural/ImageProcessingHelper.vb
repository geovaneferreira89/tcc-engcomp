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

Public Class ImageProcessingHelper

    ''' <summary> Convert a color image to monochrome </summary>
    Public Function ImageToMonochrome(ByVal img As Image) As Image
        ''' Get the source Bitmap.
        Dim bmp As New Bitmap(img)
        Dim hgt, wid As Long

        hgt = bmp.Height
        wid = bmp.Width


        Dim i, j, counter As Integer

        counter = 0
        Dim r, g, b As Integer
        For i = 0 To hgt - 1
            For j = 0 To wid - 1

                r = bmp.GetPixel(i, j).R
                g = bmp.GetPixel(i, j).G
                b = bmp.GetPixel(i, j).B
                Dim colorval As Single = (r + g + b) / 3
                Dim col As New Color()
                If colorval > 255 / 2 Then
                    col = Color.White
                Else
                    col = Color.Black
                End If
                bmp.SetPixel(j, i, col)

            Next j
        Next i

        ''' Copy the image.
        Return CType(bmp, Image)

    End Function


    '''<summary> Converts an image of any size to a pattern that
    '''can be feeded to the network.  </summary>
    '''
    '''<remarks> The product of width and height should be equal
    '''to the number of neurons in input or output layer. Basically
    '''only the monochrome version of image is converted to pattern </remarks>

    Public Function ArrayListFromImage(ByVal img As Image) As ArrayList

        Dim destination As ArrayList
        destination = New Arraylist()


        Dim bmp As New Bitmap(img)
        Dim hgt, wid As Long, clr As Color

        hgt = img.Height
        wid = img.Width

        Dim i, j As Integer

        Dim r, g, b As Integer

        For i = 0 To hgt - 1
            For j = 0 To wid - 1
                clr = bmp.GetPixel(j, i)
                '''Make it a percent value
                '''avg = avg * 100 / 255
                r = clr.R
                g = clr.G
                b = clr.B

                Dim avg As Single = (r + g + b) / 3
                If avg < (255 / 2) Then
                    destination.Add(0)
                Else
                    destination.Add(1)
                End If

            Next j
        Next i

        Return destination

    End Function

    ''' <summary> Shrinks an image in one picture box to another, using AntiAliasing </summary>
    Public Sub DrawImage(ByVal source As PictureBox, ByVal _
        target As PictureBox, Optional ByVal antialias As _
        Boolean = False)
        ''' Get the source Bitmap.

        If source.Image Is Nothing Then Exit Sub

        Dim frombm As New Bitmap(source.Image)
        DrawImage(frombm, target, antialias)

    End Sub


    ''' <summary> Shrinks a bitmap and draw it to a picture box, using AntiAliasing </summary>
    Public Sub DrawImage(ByVal bmap As Bitmap, ByVal _
        target As PictureBox, Optional ByVal antialias As _
        Boolean = False)
        ''' Get the source Bitmap.

        Dim from_bm As Bitmap = bmap

        ''' Make the destination Bitmap.
        Dim wid As Integer = target.Width
        Dim hgt As Integer = target.Height
        Dim to_bm As New Bitmap(wid, hgt)

        ''' Copy the image.
        Dim gr As Graphics = Graphics.FromImage(to_bm)
        If antialias Then gr.InterpolationMode = _
            Drawing2D.InterpolationMode.HighQualityBilinear
        gr.DrawImage(from_bm, 0, 0, wid, hgt)

        ''' Display the result.
        target.Image = to_bm
    End Sub

    ''' <summary> Shrinks a bitmap and returns the shrinked version </summary>
    Public Function ShrinkImage(ByVal bmap As Bitmap, ByVal newWidth As Integer, ByVal newHeight As Integer, Optional ByVal antialias As _
        Boolean = False) As Bitmap
        ''' Get the source Bitmap.

        Dim from_bm As Bitmap = bmap


        Dim to_bm As New Bitmap(newWidth, newHeight)

        ''' Copy the image.
        Dim gr As Graphics = Graphics.FromImage(to_bm)
        If antialias Then gr.InterpolationMode = _
            Drawing2D.InterpolationMode.HighQualityBilinear
        gr.DrawImage(from_bm, 0, 0, newWidth, newHeight)

        ''' Display the result.
        Return to_bm
    End Function

    ''' <summary> Create an image from a given pattern </summary>
    Public Function ImageFromArraylist(ByVal pattern As ArrayList, ByVal width As Integer, ByVal height As Integer) As Image

        Dim bmp As Bitmap = New Bitmap(width, height)
        Dim hgt, wid As Long
        Dim input As ArrayList = New ArrayList(), output As ArrayList = New ArrayList()



        hgt = bmp.Height
        wid = bmp.Width


        Dim i, j, counter As Integer

        counter = 0
        For i = 0 To hgt - 1
            For j = 0 To wid - 1
                Dim colorval As Integer = Math.Round(pattern(counter))
                Dim col As New Color()
                If colorval = 1 Then
                    col = Color.White
                Else
                    col = Color.Black
                End If
                bmp.SetPixel(j, i, col)
                counter = counter + 1

            Next j
        Next i

        Return CType(bmp, Image)




    End Function


End Class
