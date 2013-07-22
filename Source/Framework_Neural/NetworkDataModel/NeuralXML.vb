' Copyright 2004, Microsoft Corporation
' Sample Code - Use restricted to terms of use defined in the accompanying license agreement (EULA.doc)

'--------------------------------------------------------------
' Autogenerated by XSDObjectGen version 1.3.6.0
' Schema file: NeuralXML.xsd
' Creation Date: 4/29/2006 3:23:20 PM
'--------------------------------------------------------------

Imports System
Imports System.Xml.Serialization
Imports System.Collections
Imports System.Xml.Schema
Imports System.ComponentModel

Namespace NeuralXML.DataModel

    Public Module Declarations
        Public Const SchemaVersion As String = "http://tempuri.org/NeuralXML.xsd"
    End Module

    <Serializable()> _
    Public Enum BlockType
        <XmlEnum(Name:="Train")> Train
        <XmlEnum(Name:="Run")> Run
    End Enum

    <Serializable()> _
    Public Enum DataType
        <XmlEnum(Name:="Pattern")> Pattern
        <XmlEnum(Name:="Char")> [Char]
        <XmlEnum(Name:="Number")> Number
        <XmlEnum(Name:="Array")> Array
    End Enum


    <Serializable(), _
    EditorBrowsable(EditorBrowsableState.Advanced)> _
    Public Class NetworkCollection
        Inherits ArrayList

        Public Shadows Function Add(ByVal obj As Network) As Network
            MyBase.Add(obj)
            Add = obj
        End Function

        Public Shadows Function Add() As Network
            Add = Add(New Network())
        End Function

        Public Shadows Sub Insert(ByVal index As Integer, ByVal obj As Network)
            MyBase.Insert(index, obj)
        End Sub

        Public Shadows Sub Remove(ByVal obj As Network)
            MyBase.Remove(obj)
        End Sub

        Default Public Shadows Property Item(ByVal index As Integer) As Network
            Get
                Item = DirectCast(MyBase.Item(index), Network)
            End Get
            Set(ByVal Value As Network)
                MyBase.Item(index) = Value
            End Set
        End Property
    End Class

    <Serializable(), _
    EditorBrowsable(EditorBrowsableState.Advanced)> _
    Public Class PatternDataCollection
        Inherits ArrayList

        Public Shadows Function Add(ByVal obj As PatternData) As PatternData
            MyBase.Add(obj)
            Add = obj
        End Function

        Public Shadows Function Add() As PatternData
            Add = Add(New PatternData())
        End Function

        Public Shadows Sub Insert(ByVal index As Integer, ByVal obj As PatternData)
            MyBase.Insert(index, obj)
        End Sub

        Public Shadows Sub Remove(ByVal obj As PatternData)
            MyBase.Remove(obj)
        End Sub

        Default Public Shadows Property Item(ByVal index As Integer) As PatternData
            Get
                Item = DirectCast(MyBase.Item(index), PatternData)
            End Get
            Set(ByVal Value As PatternData)
                MyBase.Item(index) = Value
            End Set
        End Property
    End Class

    <Serializable(), _
    EditorBrowsable(EditorBrowsableState.Advanced)> _
    Public Class ImageDataCollection
        Inherits ArrayList

        Public Shadows Function Add(ByVal obj As ImageData) As ImageData
            MyBase.Add(obj)
            Add = obj
        End Function

        Public Shadows Function Add() As ImageData
            Add = Add(New ImageData())
        End Function

        Public Shadows Sub Insert(ByVal index As Integer, ByVal obj As ImageData)
            MyBase.Insert(index, obj)
        End Sub

        Public Shadows Sub Remove(ByVal obj As ImageData)
            MyBase.Remove(obj)
        End Sub

        Default Public Shadows Property Item(ByVal index As Integer) As ImageData
            Get
                Item = DirectCast(MyBase.Item(index), ImageData)
            End Get
            Set(ByVal Value As ImageData)
                MyBase.Item(index) = Value
            End Set
        End Property
    End Class

    <Serializable(), _
    EditorBrowsable(EditorBrowsableState.Advanced)> _
    Public Class DataBlockCollection
        Inherits ArrayList

        Public Shadows Function Add(ByVal obj As DataBlock) As DataBlock
            MyBase.Add(obj)
            Add = obj
        End Function

        Public Shadows Function Add() As DataBlock
            Add = Add(New DataBlock())
        End Function

        Public Shadows Sub Insert(ByVal index As Integer, ByVal obj As DataBlock)
            MyBase.Insert(index, obj)
        End Sub

        Public Shadows Sub Remove(ByVal obj As DataBlock)
            MyBase.Remove(obj)
        End Sub

        Default Public Shadows Property Item(ByVal index As Integer) As DataBlock
            Get
                Item = DirectCast(MyBase.Item(index), DataBlock)
            End Get
            Set(ByVal Value As DataBlock)
                MyBase.Item(index) = Value
            End Set
        End Property
    End Class



    '--------------------------------------------------
    'Network element
    '--------------------------------------------------
    <XmlRoot(ElementName:="Network", Namespace:=Declarations.SchemaVersion, IsNullable:=False), Serializable()> _
    Public Class Network

        <System.Runtime.InteropServices.DispIdAttribute(-4)> _
        Public Function GetEnumerator() As IEnumerator
            GetEnumerator = DataBlockCollection.GetEnumerator()
        End Function

        Public Function Add(ByVal obj As DataBlock) As DataBlock
            Add = DataBlockCollection.Add(obj)
        End Function

        <XmlIgnore()> _
        Default Public ReadOnly Property Item(ByVal index As Integer) As DataBlock
            Get
                Item = DataBlockCollection(index)
            End Get
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property Count() As Integer
            Get
                Count = DataBlockCollection.Count
            End Get
        End Property

        Public Sub Clear()
            DataBlockCollection.Clear()
        End Sub

        Public Function Remove(ByVal index As Integer) As DataBlock
            Dim obj As DataBlock
            obj = DataBlockCollection(index)
            Remove = obj
            DataBlockCollection.Remove(obj)
        End Function

        Public Sub Remove(ByVal obj As Object)
            DataBlockCollection.Remove(obj)
        End Sub

        '*********************** LoadPath attribute ***********************
        <XmlAttributeAttribute(AttributeName:="LoadPath", Form:=XmlSchemaForm.Unqualified, DataType:="string", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __LoadPath As String

        <XmlIgnore()> _
        Public Property LoadPath() As String
            Get
                LoadPath = __LoadPath
            End Get
            Set(ByVal Value As String)
                __LoadPath = Value
            End Set
        End Property

        '*********************** SaveOnFinish attribute ***********************
        <XmlAttributeAttribute(AttributeName:="SaveOnFinish", Form:=XmlSchemaForm.Unqualified, DataType:="boolean", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __SaveOnFinish As Boolean

        <XmlIgnore(), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __SaveOnFinishSpecified As Boolean

        <XmlIgnore()> _
        Public Property SaveOnFinish() As Boolean
            Get
                SaveOnFinish = __SaveOnFinish
            End Get
            Set(ByVal Value As Boolean)
                __SaveOnFinish = Value
                __SaveOnFinishSpecified = True
            End Set
        End Property

        '*********************** SavePath attribute ***********************
        <XmlAttributeAttribute(AttributeName:="SavePath", Form:=XmlSchemaForm.Unqualified, DataType:="string", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __SavePath As String

        <XmlIgnore()> _
        Public Property SavePath() As String
            Get
                SavePath = __SavePath
            End Get
            Set(ByVal Value As String)
                __SavePath = Value
            End Set
        End Property

        '*********************** DataBlock element ***********************
        <XmlElement(Type:=GetType(DataBlock), ElementName:="DataBlock", IsNullable:=False, Form:=XmlSchemaForm.Qualified, Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __DataBlockCollection As DataBlockCollection

        <XmlIgnore()> _
        Public Property DataBlockCollection() As DataBlockCollection
            Get
                If __DataBlockCollection Is Nothing Then __DataBlockCollection = New DataBlockCollection()
                DataBlockCollection = __DataBlockCollection
            End Get
            Set(ByVal Value As DataBlockCollection)
                __DataBlockCollection = Value
            End Set
        End Property

        '*********************** Constructor ***********************
        Public Sub New()
        End Sub
    End Class


    '--------------------------------------------------
    'NXML element
    '--------------------------------------------------
    <XmlRoot(ElementName:="NXML", Namespace:=Declarations.SchemaVersion, IsNullable:=False), Serializable()> _
    Public Class NXML

        <System.Runtime.InteropServices.DispIdAttribute(-4)> _
        Public Function GetEnumerator() As IEnumerator
            GetEnumerator = NetworkCollection.GetEnumerator()
        End Function

        Public Function Add(ByVal obj As Network) As Network
            Add = NetworkCollection.Add(obj)
        End Function

        <XmlIgnore()> _
        Default Public ReadOnly Property Item(ByVal index As Integer) As Network
            Get
                Item = NetworkCollection(index)
            End Get
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property Count() As Integer
            Get
                Count = NetworkCollection.Count
            End Get
        End Property

        Public Sub Clear()
            NetworkCollection.Clear()
        End Sub

        Public Function Remove(ByVal index As Integer) As Network
            Dim obj As Network
            obj = NetworkCollection(index)
            Remove = obj
            NetworkCollection.Remove(obj)
        End Function

        Public Sub Remove(ByVal obj As Object)
            NetworkCollection.Remove(obj)
        End Sub

        '*********************** Network element ***********************
        <XmlElement(Type:=GetType(Network), ElementName:="Network", IsNullable:=False, Form:=XmlSchemaForm.Qualified, Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __NetworkCollection As NetworkCollection

        <XmlIgnore()> _
        Public Property NetworkCollection() As NetworkCollection
            Get
                If __NetworkCollection Is Nothing Then __NetworkCollection = New NetworkCollection()
                NetworkCollection = __NetworkCollection
            End Get
            Set(ByVal Value As NetworkCollection)
                __NetworkCollection = Value
            End Set
        End Property

        '*********************** Constructor ***********************
        Public Sub New()
        End Sub
    End Class


    '--------------------------------------------------
    'PatternData element
    '--------------------------------------------------
    <XmlRoot(ElementName:="PatternData", Namespace:=Declarations.SchemaVersion, IsNullable:=False), Serializable()> _
    Public Class PatternData

        '*********************** InputType attribute ***********************
        <XmlAttributeAttribute(AttributeName:="InputType"), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __InputType As DataType

        <XmlIgnore(), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __InputTypeSpecified As Boolean

        <XmlIgnore()> _
        Public Property InputType() As DataType
            Get
                InputType = __InputType
            End Get
            Set(ByVal Value As DataType)
                __InputType = Value
                __InputTypeSpecified = True
            End Set
        End Property

        '*********************** InputValue attribute ***********************
        <XmlAttributeAttribute(AttributeName:="InputValue", Form:=XmlSchemaForm.Unqualified, DataType:="string", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __InputValue As String

        <XmlIgnore()> _
        Public Property InputValue() As String
            Get
                InputValue = __InputValue
            End Get
            Set(ByVal Value As String)
                __InputValue = Value
            End Set
        End Property

        '*********************** OutputType attribute ***********************
        <XmlAttributeAttribute(AttributeName:="OutputType"), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __OutputType As DataType

        <XmlIgnore(), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __OutputTypeSpecified As Boolean

        <XmlIgnore()> _
        Public Property OutputType() As DataType
            Get
                OutputType = __OutputType
            End Get
            Set(ByVal Value As DataType)
                __OutputType = Value
                __OutputTypeSpecified = True
            End Set
        End Property

        '*********************** OutputValue attribute ***********************
        <XmlAttributeAttribute(AttributeName:="OutputValue", Form:=XmlSchemaForm.Unqualified, DataType:="string", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __OutputValue As String

        <XmlIgnore()> _
        Public Property OutputValue() As String
            Get
                OutputValue = __OutputValue
            End Get
            Set(ByVal Value As String)
                __OutputValue = Value
            End Set
        End Property

        '*********************** Constructor ***********************
        Public Sub New()
        End Sub
    End Class


    '--------------------------------------------------
    'DataBlock element
    '--------------------------------------------------
    <XmlRoot(ElementName:="DataBlock", Namespace:=Declarations.SchemaVersion, IsNullable:=False), Serializable()> _
    Public Class DataBlock

        '*********************** Type attribute ***********************
        <XmlAttributeAttribute(AttributeName:="Type"), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __Type As BlockType

        <XmlIgnore(), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __TypeSpecified As Boolean

        <XmlIgnore()> _
        Public Property Type() As BlockType
            Get
                Type = __Type
            End Get
            Set(ByVal Value As BlockType)
                __Type = Value
                __TypeSpecified = True
            End Set
        End Property

        '*********************** TrainCount attribute ***********************
        <XmlAttributeAttribute(AttributeName:="TrainCount", Form:=XmlSchemaForm.Unqualified, DataType:="long", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __TrainCount As Long

        <XmlIgnore(), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __TrainCountSpecified As Boolean

        <XmlIgnore()> _
        Public Property TrainCount() As Long
            Get
                TrainCount = __TrainCount
            End Get
            Set(ByVal Value As Long)
                __TrainCount = Value
                __TrainCountSpecified = True
            End Set
        End Property

        '*********************** PatternData element ***********************
        <XmlElement(Type:=GetType(PatternData), ElementName:="PatternData", IsNullable:=False, Form:=XmlSchemaForm.Qualified, Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __PatternDataCollection As PatternDataCollection

        <XmlIgnore()> _
        Public Property PatternDataCollection() As PatternDataCollection
            Get
                If __PatternDataCollection Is Nothing Then __PatternDataCollection = New PatternDataCollection()
                PatternDataCollection = __PatternDataCollection
            End Get
            Set(ByVal Value As PatternDataCollection)
                __PatternDataCollection = Value
            End Set
        End Property

        '*********************** ImageData element ***********************
        <XmlElement(Type:=GetType(ImageData), ElementName:="ImageData", IsNullable:=False, Form:=XmlSchemaForm.Qualified, Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __ImageDataCollection As ImageDataCollection

        <XmlIgnore()> _
        Public Property ImageDataCollection() As ImageDataCollection
            Get
                If __ImageDataCollection Is Nothing Then __ImageDataCollection = New ImageDataCollection()
                ImageDataCollection = __ImageDataCollection
            End Get
            Set(ByVal Value As ImageDataCollection)
                __ImageDataCollection = Value
            End Set
        End Property

        '*********************** Constructor ***********************
        Public Sub New()
        End Sub
    End Class


    '--------------------------------------------------
    'ImageData element
    '--------------------------------------------------
    <XmlRoot(ElementName:="ImageData", Namespace:=Declarations.SchemaVersion, IsNullable:=False), Serializable()> _
    Public Class ImageData

        '*********************** InputFile attribute ***********************
        <XmlAttributeAttribute(AttributeName:="InputFile", Form:=XmlSchemaForm.Unqualified, DataType:="string", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __InputFile As String

        <XmlIgnore()> _
        Public Property InputFile() As String
            Get
                InputFile = __InputFile
            End Get
            Set(ByVal Value As String)
                __InputFile = Value
            End Set
        End Property

        '*********************** OutputFile attribute ***********************
        <XmlAttributeAttribute(AttributeName:="OutputFile", Form:=XmlSchemaForm.Unqualified, DataType:="string", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __OutputFile As String

        <XmlIgnore()> _
        Public Property OutputFile() As String
            Get
                OutputFile = __OutputFile
            End Get
            Set(ByVal Value As String)
                __OutputFile = Value
            End Set
        End Property

        '*********************** InputWidth attribute ***********************
        <XmlAttributeAttribute(AttributeName:="InputWidth", Form:=XmlSchemaForm.Unqualified, DataType:="long", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __InputWidth As Long

        <XmlIgnore(), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __InputWidthSpecified As Boolean

        <XmlIgnore()> _
        Public Property InputWidth() As Long
            Get
                InputWidth = __InputWidth
            End Get
            Set(ByVal Value As Long)
                __InputWidth = Value
                __InputWidthSpecified = True
            End Set
        End Property

        '*********************** InputHeight attribute ***********************
        <XmlAttributeAttribute(AttributeName:="InputHeight", Form:=XmlSchemaForm.Unqualified, DataType:="long", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __InputHeight As Long

        <XmlIgnore(), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __InputHeightSpecified As Boolean

        <XmlIgnore()> _
        Public Property InputHeight() As Long
            Get
                InputHeight = __InputHeight
            End Get
            Set(ByVal Value As Long)
                __InputHeight = Value
                __InputHeightSpecified = True
            End Set
        End Property

        '*********************** OutputWidth attribute ***********************
        <XmlAttributeAttribute(AttributeName:="OutputWidth", Form:=XmlSchemaForm.Unqualified, DataType:="long", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __OutputWidth As Long

        <XmlIgnore(), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __OutputWidthSpecified As Boolean

        <XmlIgnore()> _
        Public Property OutputWidth() As Long
            Get
                OutputWidth = __OutputWidth
            End Get
            Set(ByVal Value As Long)
                __OutputWidth = Value
                __OutputWidthSpecified = True
            End Set
        End Property

        '*********************** OutputHeight attribute ***********************
        <XmlAttributeAttribute(AttributeName:="OutputHeight", Form:=XmlSchemaForm.Unqualified, DataType:="long", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __OutputHeight As Long

        <XmlIgnore(), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __OutputHeightSpecified As Boolean

        <XmlIgnore()> _
        Public Property OutputHeight() As Long
            Get
                OutputHeight = __OutputHeight
            End Get
            Set(ByVal Value As Long)
                __OutputHeight = Value
                __OutputHeightSpecified = True
            End Set
        End Property

        '*********************** OutputValue attribute ***********************
        <XmlAttributeAttribute(AttributeName:="OutputValue", Form:=XmlSchemaForm.Unqualified, DataType:="string", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __OutputValue As String

        <XmlIgnore()> _
        Public Property OutputValue() As String
            Get
                OutputValue = __OutputValue
            End Get
            Set(ByVal Value As String)
                __OutputValue = Value
            End Set
        End Property

        '*********************** OutputType attribute ***********************
        <XmlAttributeAttribute(AttributeName:="OutputType"), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __OutputType As DataType

        <XmlIgnore(), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __OutputTypeSpecified As Boolean

        <XmlIgnore()> _
        Public Property OutputType() As DataType
            Get
                OutputType = __OutputType
            End Get
            Set(ByVal Value As DataType)
                __OutputType = Value
                __OutputTypeSpecified = True
            End Set
        End Property

        '*********************** Constructor ***********************
        Public Sub New()
        End Sub
    End Class
End Namespace
