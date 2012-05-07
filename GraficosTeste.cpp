//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "GraficosTeste.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
	: TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TForm1::sendClick(TObject *Sender)
{
	//Adicionar Ponto
		AnsiString data;
		data = AddX->Text;
		Series2->AddXY(AddX->Text.ToInt(),AddY->Text.ToDouble(),data,clTeeColor);
		Chart->Refresh();
		Chart->Cursor = true;

}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button1Click(TObject *Sender)
{
	//Imprimir Gráfico
	Chart->Print();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ChartMouseEnter(TObject *Sender)
{

   //Indicar algo no gráfico..
	if(Chart->GetCursorPos().X < 566 && Chart->GetCursorPos().X > 47) //X
	{
		if(Chart->GetCursorPos().Y < 300 && Chart->GetCursorPos().Y > 37) //Y
		{
		   if(HiFlag_Text_1 == "NULL")
		   {
				HiFlag_1[0] = Chart->GetCursorPos().X;
				HiFlag_1[1] = Chart->GetCursorPos().Y;
				HiFlag_Text_1 = "Teste 1";
				Chart->Canvas->AssignBrush(Chart->Walls->Back->Brush, clRed, clWhite);
				Chart->Canvas->TextOut3D(HiFlag_1[0], HiFlag_1[1],0, HiFlag_Text_1) ;
			}
			else{
				if(HiFlag_Text_2 == "NULL")
				{
					HiFlag_2[0] = Chart->GetCursorPos().X;
					HiFlag_2[1] = Chart->GetCursorPos().Y;
					HiFlag_Text_2 = "Teste 2";
					Chart->Canvas->AssignBrush(Chart->Walls->Back->Brush, clLime, clWhite);
					Chart->Canvas->TextOut3D(HiFlag_2[0], HiFlag_2[1],0, HiFlag_Text_2) ;
				}
			}
		}
	}
	//Ao clicar mostrar os Valores de X e Y do respectivo sinal.
	LabelX->Caption = "X: "+FloatToStrF(Series2->XScreenToValue(Chart->GetCursorPos().X),ffFixed,5,2);
	LabelY->Caption = "Y: "+FloatToStrF(Series2->YScreenToValue(Chart->GetCursorPos().Y),ffFixed,5,2);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormCreate(TObject *Sender)
{
	//Default, posteriormente criar uma TClass;
	HiFlag_Text_1 = "NULL";
	HiFlag_Text_2 = "NULL";

   //Gera sinal Senoidal
	AnsiString data;
	float x = 1;
	while(x < 20)
	{
		data = x;
		Series2->AddXY(x, sin(x), data, clTeeColor);
		Chart->Refresh();
		x = x + 0.4;
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ChartMouseMove(TObject *Sender, TShiftState Shift, int X,
          int Y)
{
		LabelX->Caption = "X: "+FloatToStrF(Series2->XScreenToValue(X),ffFixed,5,2);
		LabelY->Caption = "Y: "+FloatToStrF(Series2->YScreenToValue(Y),ffFixed,5,2);
		//Mostrar Cursor Vertical (Move em X)
		if(Ckb_Cursor->Checked == true)
		{
			if(X < 566 && X > 47)
			{
				Atualizar();
				Chart->Canvas->AssignVisiblePenColor(Chart->Walls->Back->Pen, clGreen);
				Chart->Canvas->VertLine3D(X, 38, 316, 0);

			}
		}
}
//---------------------------------------------------------------------------

void __fastcall TForm1::btn_limparClick(TObject *Sender)
{
	Series2->Clear();
	HiFlag_Text_1 = "NULL";
	HiFlag_Text_2 = "NULL";

}

//---------------------------------------------------------------------------
void  TForm1::Atualizar(){
	 Chart->Refresh();
	 if(HiFlag_Text_1 != "NULL")
	   {
			Chart->Canvas->AssignBrush(Chart->Walls->Back->Brush, clRed, clWhite);
			Chart->Canvas->TextOut3D(HiFlag_1[0], HiFlag_1[1],0, HiFlag_Text_1) ;
	   }

	   if(HiFlag_Text_2 != "NULL")
	   {
			Chart->Canvas->AssignBrush(Chart->Walls->Back->Brush, clLime, clWhite);
			Chart->Canvas->TextOut3D(HiFlag_2[0], HiFlag_2[1],0, HiFlag_Text_2) ;
	   }
}
//---------------------------------------------------------------------------
