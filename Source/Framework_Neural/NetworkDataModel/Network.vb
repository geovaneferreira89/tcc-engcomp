' Copyright 2004, Microsoft Corporation
' Sample Code - Use restricted to terms of use defined in the accompanying license agreement (EULA.doc)

'--------------------------------------------------------------
' Autogenerated by XSDObjectGen version 1.3.6.0
' Schema file: Network.xsd
' Creation Date: 4/19/2006 3:46:54 PM
'--------------------------------------------------------------

Imports System
Imports System.Xml.Serialization
Imports System.Collections
Imports System.Xml.Schema
Imports System.ComponentModel

Namespace DataModel

    Public Module Declarations
        Public Const SchemaVersion As String = "http://tempuri.org/Network.xsd"
    End Module

    <Serializable()> _
    Public Enum WeightInitMode
        <XmlEnum(Name:="Random")> Random
        <XmlEnum(Name:="Custom")> Custom
    End Enum

    <Serializable()> _
    Public Enum ConnectionInitMode
        <XmlEnum(Name:="All")> All
        <XmlEnum(Name:="Custom")> Custom
    End Enum


    <Serializable(), _
    EditorBrowsable(EditorBrowsableState.Advanced)> _
    Public Class InputCollection
        Inherits ArrayList

        Public Shadows Function Add(ByVal obj As Input) As Input
            MyBase.Add(obj)
            Add = obj
        End Function

        Public Shadows Function Add() As Input
            Add = Add(New Input())
        End Function

        Public Shadows Sub Insert(ByVal index As Integer, ByVal obj As Input)
            MyBase.Insert(index, obj)
        End Sub

        Public Shadows Sub Remove(ByVal obj As Input)
            MyBase.Remove(obj)
        End Sub

        Default Public Shadows Property Item(ByVal index As Integer) As Input
            Get
                Item = DirectCast(MyBase.Item(index), Input)
            End Get
            Set(ByVal Value As Input)
                MyBase.Item(index) = Value
            End Set
        End Property
    End Class

    <Serializable(), _
    EditorBrowsable(EditorBrowsableState.Advanced)> _
    Public Class NeuronCollection
        Inherits ArrayList

        Public Shadows Function Add(ByVal obj As Neuron) As Neuron
            MyBase.Add(obj)
            Add = obj
        End Function

        Public Shadows Function Add() As Neuron
            Add = Add(New Neuron())
        End Function

        Public Shadows Sub Insert(ByVal index As Integer, ByVal obj As Neuron)
            MyBase.Insert(index, obj)
        End Sub

        Public Shadows Sub Remove(ByVal obj As Neuron)
            MyBase.Remove(obj)
        End Sub

        Default Public Shadows Property Item(ByVal index As Integer) As Neuron
            Get
                Item = DirectCast(MyBase.Item(index), Neuron)
            End Get
            Set(ByVal Value As Neuron)
                MyBase.Item(index) = Value
            End Set
        End Property
    End Class

    <Serializable(), _
    EditorBrowsable(EditorBrowsableState.Advanced)> _
    Public Class LayerCollection
        Inherits ArrayList

        Public Shadows Function Add(ByVal obj As Layer) As Layer
            MyBase.Add(obj)
            Add = obj
        End Function

        Public Shadows Function Add() As Layer
            Add = Add(New Layer())
        End Function

        Public Shadows Sub Insert(ByVal index As Integer, ByVal obj As Layer)
            MyBase.Insert(index, obj)
        End Sub

        Public Shadows Sub Remove(ByVal obj As Layer)
            MyBase.Remove(obj)
        End Sub

        Default Public Shadows Property Item(ByVal index As Integer) As Layer
            Get
                Item = DirectCast(MyBase.Item(index), Layer)
            End Get
            Set(ByVal Value As Layer)
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
            GetEnumerator = LayerCollection.GetEnumerator()
        End Function

        Public Function Add(ByVal obj As Layer) As Layer
            Add = LayerCollection.Add(obj)
        End Function

        <XmlIgnore()> _
        Default Public ReadOnly Property Item(ByVal index As Integer) As Layer
            Get
                Item = LayerCollection(index)
            End Get
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property Count() As Integer
            Get
                Count = LayerCollection.Count
            End Get
        End Property

        Public Sub Clear()
            LayerCollection.Clear()
        End Sub

        Public Function Remove(ByVal index As Integer) As Layer
            Dim obj As Layer
            obj = LayerCollection(index)
            Remove = obj
            LayerCollection.Remove(obj)
        End Function

        Public Sub Remove(ByVal obj As Object)
            LayerCollection.Remove(obj)
        End Sub

        '*********************** Name attribute ***********************
        <XmlAttributeAttribute(AttributeName:="Name", Form:=XmlSchemaForm.Unqualified, DataType:="string", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __Name As String

        <XmlIgnore()> _
        Public Property Name() As String
            Get
                Name = __Name
            End Get
            Set(ByVal Value As String)
                __Name = Value
            End Set
        End Property

        '*********************** Layer element ***********************
        <XmlElement(Type:=GetType(Layer), ElementName:="Layer", IsNullable:=False, Form:=XmlSchemaForm.Qualified, Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __LayerCollection As LayerCollection

        <XmlIgnore()> _
        Public Property LayerCollection() As LayerCollection
            Get
                If __LayerCollection Is Nothing Then __LayerCollection = New LayerCollection()
                LayerCollection = __LayerCollection
            End Get
            Set(ByVal Value As LayerCollection)
                __LayerCollection = Value
            End Set
        End Property

        '*********************** Constructor ***********************
        Public Sub New()
        End Sub
    End Class


    '--------------------------------------------------
    'Input element
    '--------------------------------------------------
    <XmlRoot(ElementName:="Input", Namespace:=Declarations.SchemaVersion, IsNullable:=False), Serializable()> _
    Public Class Input

        '*********************** Layer attribute ***********************
        <XmlAttributeAttribute(AttributeName:="Layer", Form:=XmlSchemaForm.Unqualified, DataType:="long", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __Layer As Long

        <XmlIgnore(), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __LayerSpecified As Boolean

        <XmlIgnore()> _
        Public Property Layer() As Long
            Get
                Layer = __Layer
            End Get
            Set(ByVal Value As Long)
                __Layer = Value
                __LayerSpecified = True
            End Set
        End Property

        '*********************** Neuron attribute ***********************
        <XmlAttributeAttribute(AttributeName:="Neuron", Form:=XmlSchemaForm.Unqualified, DataType:="long", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __Neuron As Long

        <XmlIgnore(), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __NeuronSpecified As Boolean

        <XmlIgnore()> _
        Public Property Neuron() As Long
            Get
                Neuron = __Neuron
            End Get
            Set(ByVal Value As Long)
                __Neuron = Value
                __NeuronSpecified = True
            End Set
        End Property

        '*********************** Weight attribute ***********************
        <XmlAttributeAttribute(AttributeName:="Weight", Form:=XmlSchemaForm.Unqualified, DataType:="double", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __Weight As Double

        <XmlIgnore(), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __WeightSpecified As Boolean

        <XmlIgnore()> _
        Public Property Weight() As Double
            Get
                Weight = __Weight
            End Get
            Set(ByVal Value As Double)
                __Weight = Value
                __WeightSpecified = True
            End Set
        End Property

        '*********************** Constructor ***********************
        Public Sub New()
        End Sub
    End Class


    '--------------------------------------------------
    'Neuron element
    '--------------------------------------------------
    <XmlRoot(ElementName:="Neuron", Namespace:=Declarations.SchemaVersion, IsNullable:=False), Serializable()> _
    Public Class Neuron

        '*********************** Name attribute ***********************
        <XmlAttributeAttribute(AttributeName:="Name", Form:=XmlSchemaForm.Unqualified, DataType:="string", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __Name As String

        <XmlIgnore()> _
        Public Property Name() As String
            Get
                Name = __Name
            End Get
            Set(ByVal Value As String)
                __Name = Value
            End Set
        End Property

        '*********************** Bias element ***********************
        <XmlElement(ElementName:="Bias", IsNullable:=False, Form:=XmlSchemaForm.Qualified, DataType:="double", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __Bias As Double

        <XmlIgnore(), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __BiasSpecified As Boolean

        <XmlIgnore()> _
        Public Property Bias() As Double
            Get
                Bias = __Bias
            End Get
            Set(ByVal Value As Double)
                __Bias = Value
                __BiasSpecified = True
            End Set
        End Property

        '*********************** Output element ***********************
        <XmlElement(ElementName:="Output", IsNullable:=False, Form:=XmlSchemaForm.Qualified, DataType:="double", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __Output As Double

        <XmlIgnore(), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __OutputSpecified As Boolean

        <XmlIgnore()> _
        Public Property Output() As Double
            Get
                Output = __Output
            End Get
            Set(ByVal Value As Double)
                __Output = Value
                __OutputSpecified = True
            End Set
        End Property

        '*********************** Delta element ***********************
        <XmlElement(ElementName:="Delta", IsNullable:=False, Form:=XmlSchemaForm.Qualified, DataType:="double", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __Delta As Double

        <XmlIgnore(), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __DeltaSpecified As Boolean

        <XmlIgnore()> _
        Public Property Delta() As Double
            Get
                Delta = __Delta
            End Get
            Set(ByVal Value As Double)
                __Delta = Value
                __DeltaSpecified = True
            End Set
        End Property

        '*********************** Connections element ***********************
        <XmlElement(Type:=GetType(Connections), ElementName:="Connections", IsNullable:=False, Form:=XmlSchemaForm.Qualified, Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __Connections As Connections

        <XmlIgnore()> _
        Public Property Connections() As Connections
            Get
                If __Connections Is Nothing Then __Connections = New Connections()
                Connections = __Connections
            End Get
            Set(ByVal Value As Connections)
                __Connections = Value
            End Set
        End Property

        '*********************** Constructor ***********************
        Public Sub New()
        End Sub
    End Class


    '--------------------------------------------------
    'Connections element
    '--------------------------------------------------
    <XmlRoot(ElementName:="Connections", Namespace:=Declarations.SchemaVersion, IsNullable:=False), Serializable()> _
    Public Class Connections

        <System.Runtime.InteropServices.DispIdAttribute(-4)> _
        Public Function GetEnumerator() As IEnumerator
            GetEnumerator = InputCollection.GetEnumerator()
        End Function

        Public Function Add(ByVal obj As Input) As Input
            Add = InputCollection.Add(obj)
        End Function

        <XmlIgnore()> _
        Default Public ReadOnly Property Item(ByVal index As Integer) As Input
            Get
                Item = InputCollection(index)
            End Get
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property Count() As Integer
            Get
                Count = InputCollection.Count
            End Get
        End Property

        Public Sub Clear()
            InputCollection.Clear()
        End Sub

        Public Function Remove(ByVal index As Integer) As Input
            Dim obj As Input
            obj = InputCollection(index)
            Remove = obj
            InputCollection.Remove(obj)
        End Function

        Public Sub Remove(ByVal obj As Object)
            InputCollection.Remove(obj)
        End Sub

        '*********************** ConnectionInitMode attribute ***********************
        <XmlAttributeAttribute(AttributeName:="ConnectionInitMode"), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __ConnectionInitMode As ConnectionInitMode

        <XmlIgnore(), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __ConnectionInitModeSpecified As Boolean

        <XmlIgnore()> _
        Public Property ConnectionInitMode() As ConnectionInitMode
            Get
                ConnectionInitMode = __ConnectionInitMode
            End Get
            Set(ByVal Value As ConnectionInitMode)
                __ConnectionInitMode = Value
                __ConnectionInitModeSpecified = True
            End Set
        End Property

        '*********************** WeightInitMode attribute ***********************
        <XmlAttributeAttribute(AttributeName:="WeightInitMode"), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __WeightInitMode As WeightInitMode

        <XmlIgnore(), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __WeightInitModeSpecified As Boolean

        <XmlIgnore()> _
        Public Property WeightInitMode() As WeightInitMode
            Get
                WeightInitMode = __WeightInitMode
            End Get
            Set(ByVal Value As WeightInitMode)
                __WeightInitMode = Value
                __WeightInitModeSpecified = True
            End Set
        End Property

        '*********************** Input element ***********************
        <XmlElement(Type:=GetType(Input), ElementName:="Input", IsNullable:=False, Form:=XmlSchemaForm.Qualified, Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __InputCollection As InputCollection

        <XmlIgnore()> _
        Public Property InputCollection() As InputCollection
            Get
                If __InputCollection Is Nothing Then __InputCollection = New InputCollection()
                InputCollection = __InputCollection
            End Get
            Set(ByVal Value As InputCollection)
                __InputCollection = Value
            End Set
        End Property

        '*********************** Constructor ***********************
        Public Sub New()
        End Sub
    End Class


    '--------------------------------------------------
    'Layer element
    '--------------------------------------------------
    <XmlRoot(ElementName:="Layer", Namespace:=Declarations.SchemaVersion, IsNullable:=False), Serializable()> _
    Public Class Layer

        <System.Runtime.InteropServices.DispIdAttribute(-4)> _
        Public Function GetEnumerator() As IEnumerator
            GetEnumerator = NeuronCollection.GetEnumerator()
        End Function

        Public Function Add(ByVal obj As Neuron) As Neuron
            Add = NeuronCollection.Add(obj)
        End Function

        <XmlIgnore()> _
        Default Public ReadOnly Property Item(ByVal index As Integer) As Neuron
            Get
                Item = NeuronCollection(index)
            End Get
        End Property

        <XmlIgnore()> _
        Public ReadOnly Property Count() As Integer
            Get
                Count = NeuronCollection.Count
            End Get
        End Property

        Public Sub Clear()
            NeuronCollection.Clear()
        End Sub

        Public Function Remove(ByVal index As Integer) As Neuron
            Dim obj As Neuron
            obj = NeuronCollection(index)
            Remove = obj
            NeuronCollection.Remove(obj)
        End Function

        Public Sub Remove(ByVal obj As Object)
            NeuronCollection.Remove(obj)
        End Sub

        '*********************** Name attribute ***********************
        <XmlAttributeAttribute(AttributeName:="Name", Form:=XmlSchemaForm.Unqualified, DataType:="string", Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __Name As String

        <XmlIgnore()> _
        Public Property Name() As String
            Get
                Name = __Name
            End Get
            Set(ByVal Value As String)
                __Name = Value
            End Set
        End Property

        '*********************** Neuron element ***********************
        <XmlElement(Type:=GetType(Neuron), ElementName:="Neuron", IsNullable:=False, Form:=XmlSchemaForm.Qualified, Namespace:=Declarations.SchemaVersion), _
        EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public __NeuronCollection As NeuronCollection

        <XmlIgnore()> _
        Public Property NeuronCollection() As NeuronCollection
            Get
                If __NeuronCollection Is Nothing Then __NeuronCollection = New NeuronCollection()
                NeuronCollection = __NeuronCollection
            End Get
            Set(ByVal Value As NeuronCollection)
                __NeuronCollection = Value
            End Set
        End Property

        '*********************** Constructor ***********************
        Public Sub New()
        End Sub
    End Class
End Namespace
