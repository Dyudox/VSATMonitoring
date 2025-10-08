<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="LaporanPekerjaan.aspx.vb" Inherits="LaporanPekerjaan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">    
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
								<input class="form-control" type="text" placeholder="input here..." value="Sigit asturi" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-2 control-label">KOORDINATOR :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="BANG SYAFIG" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-2 control-label">PIC 1 :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="Dahlan - 081240367827 / 081248555147" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-2 control-label">TIBA DILOKASI :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="21 agustus 2025 JAM 20.08 WIT" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-2 control-label">TGL/Jam Mulai :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="22 Agustus 2025 JAM 21:15WIT" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-2 control-label">TGL/Jam Selesai :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="22 Agustus 2025 JAM 14: 00 WIT  ( MONITORING )- sampai pagi" />
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
							<label class="col-lg-2 control-label">NAMA TEKNISI/ NO HP :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="Sigit asturi" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-2 control-label">KOORDINATOR :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="BANG SYAFIG" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-2 control-label">PIC 1 :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="Dahlan - 081240367827 / 081248555147" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-2 control-label">TIBA DILOKASI :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="21 agustus 2025 JAM 20.08 WIT" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-2 control-label">TGL/Jam Mulai :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="22 Agustus 2025 JAM 21:15WIT" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-2 control-label">TGL/Jam Selesai :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="22 Agustus 2025 JAM 14: 00 WIT  ( MONITORING )- sampai pagi" />
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
							<label class="col-lg-2 control-label">NAMA TEKNISI/ NO HP :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="Sigit asturi" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-2 control-label">KOORDINATOR :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="BANG SYAFIG" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-2 control-label">PIC 1 :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="Dahlan - 081240367827 / 081248555147" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-2 control-label">TIBA DILOKASI :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="21 agustus 2025 JAM 20.08 WIT" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-2 control-label">TGL/Jam Mulai :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="22 Agustus 2025 JAM 21:15WIT" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-2 control-label">TGL/Jam Selesai :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="22 Agustus 2025 JAM 14: 00 WIT  ( MONITORING )- sampai pagi" />
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
							<label class="col-lg-2 control-label">NAMA TEKNISI/ NO HP :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="Sigit asturi" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-2 control-label">KOORDINATOR :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="BANG SYAFIG" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-2 control-label">PIC 1 :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="Dahlan - 081240367827 / 081248555147" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-2 control-label">TIBA DILOKASI :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="21 agustus 2025 JAM 20.08 WIT" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-2 control-label">TGL/Jam Mulai :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="22 Agustus 2025 JAM 21:15WIT" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-2 control-label">TGL/Jam Selesai :</label>
							<div class="col-lg-10">
								<input class="form-control" type="text" placeholder="input here..." value="22 Agustus 2025 JAM 14: 00 WIT  ( MONITORING )- sampai pagi" />
							</div>
						</div>
						<hr style="border-block: groove" />						
					</div>
				</div>
			</div>
		</div><!-- /panel -->			
	</div><!-- /.padding-md -->	
</asp:Content>

