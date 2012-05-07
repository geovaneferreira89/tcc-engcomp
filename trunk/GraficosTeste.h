//---------------------------------------------------------------------------

#ifndef GraficosTesteH
#define GraficosTesteH
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <Vcl.Controls.hpp>
#include <Vcl.StdCtrls.hpp>
#include <Vcl.Forms.hpp>
#include <Vcl.ExtCtrls.hpp>
#include <VCLTee.Chart.hpp>
#include <VCLTee.TeEngine.hpp>
#include <VCLTee.TeeProcs.hpp>
#include <VCLTee.Series.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
	TChart *Chart;
	TButton *send;
	TEdit *AddX;
	TFastLineSeries *Series2;
	TEdit *AddY;
	TButton *Button1;
	TLabel *LabelX;
	TLabel *LabelY;
	TCheckBox *Ckb_Cursor;
	TButton *btn_limpar;
	void __fastcall sendClick(TObject *Sender);
	void __fastcall Button1Click(TObject *Sender);
	void __fastcall ChartMouseEnter(TObject *Sender);
	void __fastcall FormCreate(TObject *Sender);
	void __fastcall ChartMouseMove(TObject *Sender, TShiftState Shift, int X, int Y);
	void __fastcall btn_limparClick(TObject *Sender);



private:	// User declarations
//Flags somente 2 atualmente.
	float 		HiFlag_1[2];
	AnsiString  HiFlag_Text_1;
	float 		HiFlag_2[2];
	AnsiString  HiFlag_Text_2;

public:		// User declarations
	void	Atualizar();
	__fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
