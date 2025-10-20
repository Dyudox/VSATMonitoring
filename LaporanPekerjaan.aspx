<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="LaporanPekerjaan.aspx.vb" Inherits="LaporanPekerjaan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">  
	<div id="divExport" runat="server">
		<div class="padding-md">			
			<div class="panel panel-default">				
				<div class="panel-body">
					<div class="panel-heading">
						<%--FORMAT LAPORAN PEKERJAAN PM BAKTI SCMEDIA--%>					
						<label>LAPORAN PEKERJAAN ( CM, PM, PSB, RELOKASI ) SCM</label><br />
						<span>JENIS LAYANAN :  VSAT</span><br />
						<span>JENIS PEKERJAAN : CM</span>
						<%--<span class="pull-right">
							<label class="label-checkbox inline">
								<input type="checkbox" id="toggleLine" checked>
								<span class="custom-checkbox"></span>
								Toggle Line
							</label>
						</span>--%>
					</div>				
					<div class="panel-body">
						<div class="form-horizontal no-margin form-border">
							<div class="panel-heading" style="padding: 10px 15px 0px;">
								<div>
									<label>1. REMOTE SUPPORT TIM</label>
								</div><!-- /input-group -->
							</div>
							<hr style="border-block: groove; margin-top: 0px; margin-bottom: 20px;" />
							<div class="form-group">
								<label class="col-lg-2 control-label">NAMA TEKNISI/ NO HP :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtNameTeknisi" runat="server" value="Sigit asturi" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">KOORDINATOR :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtKoordinator" runat="server" value="BANG SYAFIG" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">TGL/Jam Tiba :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtTglTiba" runat="server" value="Dahlan - 081240367827 / 081248555147" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">TGL/Jam Mulai :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtTglMulai" runat="server" value="21 agustus 2025 JAM 20.08 WIT" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">TGL/ Jam Online :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtTglOnline" runat="server" value="22 Agustus 2025 JAM 21:15WIT" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">TGL/Jam Selesai :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtTglSelesai" runat="server" value="22 Agustus 2025 JAM 14: 00 WIT  ( MONITORING )- sampai pagi" />
								</div>
							</div>
							<hr style="border-block: groove" />						
						</div>
						<div class="form-horizontal no-margin form-border">
							<div class="panel-heading" style="padding: 10px 15px 0px;">
								<div>
									<label>2. CUSTOMER</label>
								</div><!-- /input-group -->
							</div>
							<hr style="border-block: groove; margin-top: 0px; margin-bottom: 20px;" />
							<div class="form-group">
								<label class="col-lg-2 control-label">NAMA CUSTOMER :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtNameCust" runat="server" value="Sigit asturi" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">ALAMAT :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtAlamat" runat="server" value="BANG SYAFIG" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">KOTA/KAB :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtKotaKab" runat="server" value="Dahlan - 081240367827 / 081248555147" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">PROVINSI :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtProv" runat="server" value="21 agustus 2025 JAM 20.08 WIT" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SITE ID :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSiteID" runat="server" value="22 Agustus 2025 JAM 21:15WIT" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">PIC LOKASI :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtPicLok" runat="server" value="22 Agustus 2025 JAM 14: 00 WIT  ( MONITORING )- sampai pagi" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">IP LAN :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtIPLan" runat="server" value="127.0.0.1" />
								</div>
							</div>
							<hr style="border-block: groove" />						
						</div>
						<div class="form-horizontal no-margin form-border">
							<div class="panel-heading" style="padding: 10px 15px 0px;">
								<div>
									<label>3. PERANGKAT TERPASANG</label>
								</div><!-- /input-group -->
							</div>
							<hr style="border-block: groove; margin-top: 0px; margin-bottom: 20px;" />
							<div class="form-group">
								<label class="col-lg-2 control-label">
									<b style="font-size:large">VSAT :</b>
								</label>								
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">JENIS ANTENNA :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtJenisAntena" runat="server" value="Sigit asturi" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">JENIS MOUNTING :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtJenisMounting" runat="server" value="BANG SYAFIG" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">JENIS IFL :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtJenisIFL" runat="server" value="(rg11 50m)" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">TYPE MODEM :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtTypeModem" runat="server" value="21 agustus 2025 JAM 20.08 WIT" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SN MODEM :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSNModem" runat="server" value="22 Agustus 2025 JAM 21:15WIT" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">ESN MODEM :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtESNModem" runat="server" value="22 Agustus 2025 JAM 14: 00 WIT  ( MONITORING )- sampai pagi" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SN ADAPTOR MODEM :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSNAdaptModem" runat="server" value="22 Agustus 2025 JAM 14: 00 WIT  ( MONITORING )- sampai pagi" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SN BUC :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSNBuc" runat="server" value="22 Agustus 2025 JAM 14: 00 WIT  ( MONITORING )- sampai pagi" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SN LNB :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSNLnb" runat="server" value="22 Agustus 2025 JAM 14: 00 WIT  ( MONITORING )- sampai pagi" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SN ROUTER :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSNRouter" runat="server" value=":(sn mikrotik)" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SN ADAPTOR ROUTER :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSNAdapterRouter" runat="server" value="2346758763355245" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SN AP :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSN_AP" runat="server" value="0987654323435678676" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SN ADAPTOR AP :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSNAdapterAP" runat="server" value="1345678943253464879" />
								</div>
							</div>							
							<div class="form-group">
								<label class="col-lg-2 control-label">
									<b style="font-size:large">M2M :</b>
								</label>							
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">TYPE MODEM :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtTypeModemM2M" runat="server" value="(Robustel R2010 /R1510)" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SN MODEM :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSNModemM2M" runat="server" value="8765345678907" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SN ADAPTOR :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSNAdapterM2M" runat="server" value="42543564674" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">NO SIMCARD :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtNoSimCard" runat="server" value="7654354678789" />
								</div>
							</div>							
							<hr style="border-block: groove" />						
						</div>
						<div class="form-horizontal no-margin form-border">
							<div class="panel-heading" style="padding: 10px 15px 0px;">
								<div>
									<label>4. PERANGKAT RUSAK</label>
								</div><!-- /input-group -->
							</div>
							<hr style="border-block: groove; margin-top: 0px; margin-bottom: 20px;" />
							<div class="form-group">
								<label class="col-lg-2 control-label">
									<b style="font-size:large">VSAT :</b>
								</label>								
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">TYPE MODEM LAMA :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtTypeModemLama" runat="server" value="154678978654" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SN MODEM LAMA :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSNModemLama" runat="server" value="6543453478678" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">ESN MODEM LAMA :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtESNModelLama" runat="server" value="564534324247486" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SN ADAPTOR LAMA :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSNAdaptLama" runat="server" value="654534534523746" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SN LNB LAMA :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSNLnbLama" runat="server" value="54434378980976" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SN BUC LAMA :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSNBucLama" runat="server" value="9874567890989765" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SN ROUTER LAMA :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSNRouterLama" runat="server" value="(sn microtik)" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SN ADAPTOR ROUTER LAMA :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSNAdaptRouterLama" runat="server" value="254367887654634" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SN AP LAMA :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSN_APLama" runat="server" value="78653464573545" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SN ADAPTOR AP LAMA :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSNAdaptAPLama" runat="server" value=":7652742564564" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">
									<b style="font-size:large">M2M :</b>
								</label>								
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">TYPE MODEM LAMA :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtTypeRouterLama" runat="server" value="3453780-98756" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SN MODEM LAMA :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSNModemLamaM2M" runat="server" value="3243489676786" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SN ADAPTOR LAMA :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSNAdaptLamaM2M" runat="server" value="42543564674" />
								</div>
							</div>
							<hr style="border-block: groove" />		
						</div>
						<div class="form-horizontal no-margin form-border">
							<div class="panel-heading" style="padding: 10px 15px 0px;">
								<div>
									<label>5. INFORMASI PARAMETER</label>
								</div><!-- /input-group -->
							</div>
							<hr style="border-block: groove; margin-top: 0px; margin-bottom: 20px;" />
							<div class="form-group">
								<label class="col-lg-2 control-label">
									<b style="font-size:large">VSAT :</b>
								</label>								
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">HUB/SATELITE :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtHubSatelit" runat="server" value="CIB4" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SQF AWAL :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSQFAwal" runat="server" value="76" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SQF POINTING :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtSQFPointing" runat="server" value="78" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">INITIAL ESNO :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtInsialESNO" runat="server" value="180" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">TARGET ESNO :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtTargetESNO" runat="server" value="120" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">
									<b style="font-size:large">HASIL XPOL :</b>
								</label>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">CPI :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtCPI" runat="server" value="3453780-98756" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">C/N :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtCN" runat="server" value="3243489676786" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">ASIASAT :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtASIASAT" runat="server" value="42543564674" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">CHINASAT :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtChinaSat" runat="server" value="42543564674" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">PETUGAS TCC :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtPetugasTCC" runat="server" value="42543564674" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">PETUGAS HD :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtPetugasHD" runat="server" value="42543564674" />
								</div>
							</div>
							<div class="form-group">
								<div class="form-group">
									<label class="col-lg-2 control-label">
										<b style="font-size:large">SIGNAL M2M :</b>
									</label>
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">Telkomsel :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtTelkomsel" runat="server" value="3453780-98756" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">Indosat :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtIndosat" runat="server" value="3243489676786" />
								</div>
							</div>
							<hr style="border-block: groove" />		
						</div>
						<div class="form-horizontal no-margin form-border">
							<div class="panel-heading" style="padding: 10px 15px 0px;">
								<div>
									<label>6. INFOMASI SARPEN</label>
								</div><!-- /input-group -->
							</div>
							<hr style="border-block: groove; margin-top: 0px; margin-bottom: 20px;" />
							<div class="form-group">
								<label class="col-lg-2 control-label">KONDISI AC :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtKondisiAC" runat="server" value="CIB4" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">KONDISI BLOWER BOX :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtKondisiBlower" runat="server" value="76" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">SUMBER ELEKTRIKAL :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtElectrical" runat="server" value="(ups, pln)" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">P-N :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtPN" runat="server" value="210" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">P-G :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtPG" runat="server" value="220" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">N-G :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtNG" runat="server" value="2.3" />
								</div>
							</div>
							<hr style="border-block: groove" />		
						</div>
						<div class="form-horizontal no-margin form-border">
							<div class="panel-heading" style="padding: 10px 15px 0px;">
								<div>
									<label>7. DETAIL ACTION TEKNISI</label>
								</div><!-- /input-group -->
							</div>
							<hr style="border-block: groove; margin-top: 0px; margin-bottom: 20px;" />
							<div class="form-group">
								<label class="col-lg-2 control-label">TINDAKAN YANG  DILAKUKAN TEKNISI :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtTidakanTeknisi" runat="server" value="Installasi" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">TINDAKAN YANG DILAKUKAN FLM :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtTindakanFLM" runat="server" value="Pergantian kabel" />
								</div>
							</div>
							<hr style="border-block: groove" />		
						</div>
						<div class="form-horizontal no-margin form-border">
							<div class="panel-heading" style="padding: 10px 15px 0px;">
								<div>
									<label>8. CATATAN</label>
								</div><!-- /input-group -->
							</div>
							<hr style="border-block: groove; margin-top: 0px; margin-bottom: 20px;" />
							<div class="form-group">
								<label class="col-lg-2 control-label">PENYEBAB GANGGUAN :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtGamas" runat="server" value="Lost Signal " />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">PERANGKAT YG DIGANTI :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtGantiPerangkat" runat="server" value="Antena" />
								</div>
							</div>
							<div class="form-group">
								<label class="col-lg-2 control-label">CATATAN :</label>
								<div class="col-lg-10">
									<input class="form-control" type="text" placeholder="input here..." id="txtNotes" runat="server" value="Notes" />
								</div>
							</div>
							<hr style="border-block: groove" />		
						</div>
					</div>
				</div>
			</div><!-- /panel -->			
		</div><!-- /.padding-md -->	
	</div>	
	<div>
		<asp:Button ID="btn_exportTxt" class="btn btn-info" runat="server" OnClick="btn_exportTxt_Click" Text="Convert To .txt" />
	</div>
</asp:Content>

