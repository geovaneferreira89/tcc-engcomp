object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 395
  ClientWidth = 598
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object LabelX: TLabel
    Left = 530
    Top = 24
    Width = 62
    Height = 13
    Caption = 'Cordenada X'
  end
  object LabelY: TLabel
    Left = 530
    Top = 8
    Width = 62
    Height = 13
    Caption = 'Cordenada Y'
  end
  object Chart: TChart
    Left = 8
    Top = 39
    Width = 584
    Height = 351
    Cursor = crArrow
    LeftWall.Color = clBlack
    Title.Text.Strings = (
      'TChart')
    Pages.AutoScale = True
    RightAxis.LabelsAlternate = True
    RightAxis.LabelsMultiLine = True
    RightAxis.LabelsBehind = True
    SeriesGroups = <
      item
        Name = 'Group1'
      end>
    TopAxis.LabelsSeparation = 0
    View3D = False
    View3DOptions.Orthogonal = False
    View3DOptions.Zoom = 97
    Zoom.Animated = True
    TabOrder = 0
    OnClick = ChartMouseEnter
    OnMouseMove = ChartMouseMove
    PrintMargins = (
      15
      23
      15
      23)
    ColorPaletteIndex = 11
    object Series2: TFastLineSeries
      Marks.Arrow.Visible = True
      Marks.Callout.Brush.Color = clBlack
      Marks.Callout.Arrow.Visible = True
      Marks.Emboss.Color = 8553090
      Marks.Shadow.Color = 8684676
      Marks.Visible = False
      SeriesColor = 33023
      ShowInLegend = False
      LinePen.Color = 33023
      LinePen.Width = 3
      XValues.Name = 'X'
      XValues.Order = loAscending
      YValues.Name = 'Y'
      YValues.Order = loNone
    end
  end
  object send: TButton
    Left = 11
    Top = 8
    Width = 54
    Height = 25
    Caption = 'Plotar'
    TabOrder = 1
    OnClick = sendClick
  end
  object AddX: TEdit
    Left = 19
    Top = 361
    Width = 26
    Height = 21
    TabOrder = 2
    Text = '0'
  end
  object AddY: TEdit
    Left = 19
    Top = 46
    Width = 26
    Height = 21
    TabOrder = 3
    Text = '1'
  end
  object Button1: TButton
    Left = 131
    Top = 8
    Width = 57
    Height = 25
    Caption = 'Imprimir'
    TabOrder = 4
    OnClick = Button1Click
  end
  object Ckb_Cursor: TCheckBox
    Left = 474
    Top = 14
    Width = 50
    Height = 15
    Caption = 'Cursor'
    TabOrder = 5
  end
  object btn_limpar: TButton
    Left = 71
    Top = 8
    Width = 54
    Height = 25
    Caption = 'Limpar'
    TabOrder = 6
    OnClick = btn_limparClick
  end
  object Button2: TButton
    Left = 208
    Top = 8
    Width = 57
    Height = 25
    Caption = 'Button2'
    TabOrder = 7
  end
end
