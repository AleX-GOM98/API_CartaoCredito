
string GerarCC()
        {
           

            string CCBIN = txtBIN.Text.Trim().Replace(" ", "");
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            txtCCGerado.Clear();
            string CCBin = txtBIN.Text.Trim().Replace(" ", "");

            if (cboxChecker.SelectedIndex == 0)
            {
                for (int i = 0; i < QuantidadeCC.Value; i++)
                {
                    string CC = "";
                    int CCBinLength = CCBin.Length - 1;
                    for (int j = 0; j < CCBinLength; j++)
                    {
                        if (CCBin[j].ToString().ToUpper() == "X")
                        {
                            CC += (rnd.Next(0, 10));
                        }
                        else if (CCBin[j].ToString().ToUpper() == "M")
                        {
                            CC += (rnd.Next(1, 6));
                        }
                        else if (CCBin[j].ToString().ToUpper() == "A")
                        {
                            if (rnd.Next(1, 3) == 1)
                            {
                                CC += 4;
                            }
                            else
                            {
                                CC += 7;
                            }
                        }
                        else
                        {
                            CC += (CCBin[j]);
                        }
                    }

                    int Soma = 0, a = 0, d;
                    for (int j = CC.Length; j > 0; j--)
                    {
                        d = int.Parse(CC.Substring(j - 1, 1));
                        if (a % 2 == 0)
                        {
                            d *= 2;
                        }

                        if (d > 9)
                        {
                            d -= 9;
                        }

                        Soma += d;
                        a++;
                    }

                    int DV = 10 - (Soma % 10);
                    if (DV == 10)
                    {
                        DV = 0;
                    }

                    sb.Append(CC + DV);

                    if (checkData.Checked)
                    {
                        string Mes;
                        if (cboxMes.SelectedIndex == 0)
                        {
                            Mes = rnd.Next(1, 13).ToString();
                        }
                        else
                        {
                            Mes = cboxMes.Text;
                        }

                        if (Mes.Length == 1)
                        {
                            Mes = "0" + Mes;
                        }

                        Mes = Mes + "|";

                        string Ano;
                        if (cboxAno.SelectedIndex == 0)
                        {
                            Ano = rnd.Next(2018, 2026).ToString();
                        }
                        else
                        {
                            Ano = cboxAno.Text;
                        }

                        if (Ano.Length == 2)
                        {
                            Ano = "20" + Ano;
                        }

                        sb.Append("|" + Mes + Ano);
                    }
                    if (checkCVV.Checked)
                    {
                        string CVV;
                        if (txtCVV.Text.ToLower() == "rnd")
                        {
                            if ((CC.Substring(0, 2) == "37" || CC.Substring(0, 2) == "34") && CC.Length + 1 == 15)
                            {
                                CVV = rnd.Next(1000, 9999).ToString();
                            }
                            else if (CC.Substring(0, 4) == "6011" && CC.Length + 1 == 16)
                            {
                                CVV = rnd.Next(1000, 9999).ToString();
                            }
                            else
                            {
                                CVV = rnd.Next(101, 999).ToString();
                            }
                        }
                        else
                        {
                            CVV = txtCVV.Text;
                        }

                        sb.Append("|" + CVV);
                    }
                    if (checkTipobanco.Checked)
                    {
                        string TipoBanco = "";
                        string CCDV = CC + DV;
                        for (int j = 0; j < BinsPreDefinidos.Length; j++)
                        {
                            if (CCBIN.Substring(0, 6) == BinsPreDefinidos[j].Trim().Replace(" ", "").Replace("X", ""))
                            {
                                TipoBanco = "|" + cboxBins.Items[j + 1].ToString();
                                j = BinsPreDefinidos.Length;
                            }
                        }

                        if (TipoBanco == "")
                        {
                            if (CCDV.Substring(0, 1) == "4" && (CCDV.Length == 13 || CCDV.Length == 16))
                            {
                                TipoBanco = "|Visa";
                            }
                            else if ((CCDV.Substring(0, 2) == "51" || CCDV.Substring(0, 2) == "52" || CCDV.Substring(0, 2) == "53" || CCDV.Substring(0, 2) == "54" || CCDV.Substring(0, 2) == "55") && CCDV.Length == 16)
                            {
                                TipoBanco = "|Mastercard";
                            }
                            else if ((CCDV.Substring(0, 2) == "34" || CCDV.Substring(0, 2) == "37") && CCDV.Length == 15)
                            {
                                TipoBanco = "|American Express";
                            }
                            else if (CCDV.Substring(0, 4) == "6011" && CCDV.Length == 16)
                            {
                                TipoBanco = "|Discover";
                            }
                            else if ((CCDV.Substring(0, 4) == "3528" || CCDV.Substring(0, 4) == "3088" || CCDV.Substring(0, 4) == "3096" || CCDV.Substring(0, 4) == "3112" || CCDV.Substring(0, 4) == "3158" || CCDV.Substring(0, 4) == "3096" || CCDV.Substring(0, 4) == "3337") && CCDV.Length == 16)
                            {
                                TipoBanco = "|JCB";
                            }
                            else if ((CCDV.Substring(0, 2) == "30" || CCDV.Substring(0, 2) == "36" || CCDV.Substring(0, 2) == "38") && (CCDV.Length == 14 || CCDV.Length == 16))
                            {
                                TipoBanco = "|Diners Club";
                            }
                            else if ((CCDV.Substring(0, 4) == "2014" || CCDV.Substring(0, 4) == "2149") && CCDV.Length == 15)
                            {
                                TipoBanco = "|enRoute";
                            }
                            else if (CCDV.Substring(0, 6) == "606282" && (CCDV.Length == 13 || CCDV.Length == 16 || CCDV.Length == 19))
                            {
                                TipoBanco = "|Hipercard";
                            }
                            else if ((CCDV.Substring(0, 6) == "636368" || CCDV.Substring(0, 6) == "636369" || CCDV.Substring(0, 6) == "438935" || CCDV.Substring(0, 6) == "504175" || CCDV.Substring(0, 6) == "451416" || CCDV.Substring(0, 6) == "636297" || CCDV.Substring(0, 4) == "5067" || CCDV.Substring(0, 4) == "4576" || CCDV.Substring(0, 4) == "4011" || CCDV.Substring(0, 6) == "506699") && CCDV.Length == 16)
                            {
                                TipoBanco = "|Elo";
                            }
                            else if (CCDV.Substring(0, 2) == "50" && CCDV.Length == 16)
                            {
                                TipoBanco = "|Aura";
                            }
                            else if ((CCDV.Substring(0, 4) == "4903" || CCDV.Substring(0, 4) == "4911" || CCDV.Substring(0, 4) == "4936" || CCDV.Substring(0, 4) == "5641" || CCDV.Substring(0, 4) == "6333" || CCDV.Substring(0, 4) == "6759" || CCDV.Substring(0, 4) == "6334" || CCDV.Substring(0, 4) == "6767") && CCDV.Length == 13)
                            {
                                TipoBanco = "|Switch";
                            }
                            else
                            {
                                TipoBanco = "|Desconhecido";
                            }
                        }

                        sb.Append(TipoBanco);
                    }

                    sb.Append(Environment.NewLine);
                }

                txtCCGerado.Text = sb.ToString();
                txtCCGerado.Text = txtCCGerado.Text.Trim();
            }
            else if (cboxChecker.SelectedIndex == 1)
            {
                for (int i = 0; i < QuantidadeCC.Value; i++)
                {
                    string CC = "";
                    int CCBinLength = CCBin.Length - 1;
                    for (int j = 0; j < CCBinLength; j++)
                    {
                        if (CCBin[j].ToString().ToUpper() == "X")
                        {
                            CC += (rnd.Next(0, 10));
                        }
                        else if (CCBin[j].ToString().ToUpper() == "M")
                        {
                            CC += (rnd.Next(1, 6));
                        }
                        else if (CCBin[j].ToString().ToUpper() == "A")
                        {
                            if (rnd.Next(1, 3) == 1)
                            {
                                CC += 4;
                            }
                            else
                            {
                                CC += 7;
                            }
                        }
                        else
                        {
                            CC += (CCBin[j]);
                        }
                    }

                    int Soma = 0, a = 0, d;
                    for (int j = CC.Length; j > 0; j--)
                    {
                        d = int.Parse(CC.Substring(j - 1, 1));
                        if (a % 2 == 0)
                        {
                            d *= 2;
                        }
                        if (d > 9)
                        {
                            d -= 9;
                        }
                        Soma += d;
                        a++;
                    }

                    int DV = 10 - (Soma % 10);
                    if (DV == 10)
                    {
                        DV = 0;
                    }

                    sb.Append(CC + DV);

                    if (checkCVV.Checked)
                    {
                        string CVV;
                        if (txtCVV.Text.ToLower() == "rnd")
                        {
                            if ((CC.Substring(0, 2) == "37" || CC.Substring(0, 2) == "34") && CC.Length + 1 == 15)
                            {
                                CVV = rnd.Next(1000, 9999).ToString();
                            }
                            else if (CC.Substring(0, 4) == "6011" && CC.Length + 1 == 16)
                            {
                                CVV = rnd.Next(1000, 9999).ToString();
                            }
                            else
                            {
                                CVV = rnd.Next(101, 999).ToString();
                            }
                        }
                        else
                        {
                            CVV = txtCVV.Text;
                        }

                        sb.Append(", " + CVV);
                    }
                    if (checkData.Checked)
                    {
                        string Mes;
                        if (cboxMes.SelectedIndex == 0)
                        {
                            Mes = rnd.Next(1, 13).ToString();
                        }
                        else
                        {
                            Mes = cboxMes.Text;
                        }

                        if (Mes.Length == 1)
                        {
                            Mes = "0" + Mes;
                        }

                        Mes = Mes + "/";

                        string Ano;
                        if (cboxAno.SelectedIndex == 0)
                        {
                            Ano = rnd.Next(2018, 2026).ToString();
                        }
                        else
                        {
                            Ano = cboxAno.Text;
                        }

                        if (Ano.Length == 2)
                        {
                            Ano = "20" + Ano;
                        }

                        sb.Append(", " + Mes + Ano);
                    }
                    if (checkTipobanco.Checked)
                    {
                        string TipoBanco = "";
                        string CCDV = CC + DV;
                        for (int j = 0; j < BinsPreDefinidos.Length; j++)
                        {
                            if (CCBIN.Substring(0, 6) == BinsPreDefinidos[j].Trim().Replace(" ", "").Replace("X", ""))
                            {
                                TipoBanco = ", " + cboxBins.Items[j + 1].ToString();
                                j = BinsPreDefinidos.Length;
                            }
                        }
                        if (TipoBanco == "")
                        {
                            if (CCDV.Substring(0, 1) == "4" && (CCDV.Length == 13 || CCDV.Length == 16))
                            {
                                TipoBanco = ", Visa";
                            }
                            else if ((CCDV.Substring(0, 2) == "51" || CCDV.Substring(0, 2) == "52" || CCDV.Substring(0, 2) == "53" || CCDV.Substring(0, 2) == "54" || CCDV.Substring(0, 2) == "55") && CCDV.Length == 16)
                            {
                                TipoBanco = ", Mastercard";
                            }
                            else if ((CCDV.Substring(0, 2) == "34" || CCDV.Substring(0, 2) == "37") && CCDV.Length == 15)
                            {
                                TipoBanco = ", American Express";
                            }
                            else if (CCDV.Substring(0, 4) == "6011" && CCDV.Length == 16)
                            {
                                TipoBanco = ", Discover";
                            }
                            else if ((CCDV.Substring(0, 4) == "3528" || CCDV.Substring(0, 4) == "3088" || CCDV.Substring(0, 4) == "3096" || CCDV.Substring(0, 4) == "3112" || CCDV.Substring(0, 4) == "3158" || CCDV.Substring(0, 4) == "3096" || CCDV.Substring(0, 4) == "3337") && CCDV.Length == 16)
                            {
                                TipoBanco = ", JCB";
                            }
                            else if ((CCDV.Substring(0, 2) == "30" || CCDV.Substring(0, 2) == "36" || CCDV.Substring(0, 2) == "38") && (CCDV.Length == 14 || CCDV.Length == 16))
                            {
                                TipoBanco = ", Diners Club";
                            }
                            else if ((CCDV.Substring(0, 4) == "2014" || CCDV.Substring(0, 4) == "2149") && CCDV.Length == 15)
                            {
                                TipoBanco = ", enRoute";
                            }
                            else if ((CCDV.Substring(0, 6) == "606282") && (CCDV.Length == 13 || CCDV.Length == 16 || CCDV.Length == 19))
                            {
                                TipoBanco = ", Hipercard";
                            }
                            else if ((CCDV.Substring(0, 6) == "636368" || CCDV.Substring(0, 6) == "636369" || CCDV.Substring(0, 6) == "438935" || CCDV.Substring(0, 6) == "504175" || CCDV.Substring(0, 6) == "451416" || CCDV.Substring(0, 6) == "636297" || CCDV.Substring(0, 4) == "5067" || CCDV.Substring(0, 4) == "4576" || CCDV.Substring(0, 4) == "4011" || CCDV.Substring(0, 6) == "506699") && CCDV.Length == 16)
                            {
                                TipoBanco = ", Elo";
                            }
                            else if (CCDV.Substring(0, 2) == "50" && CCDV.Length == 16)
                            {
                                TipoBanco = ", Aura";
                            }
                            else if ((CCDV.Substring(0, 4) == "4903" || CCDV.Substring(0, 4) == "4911" || CCDV.Substring(0, 4) == "4936" || CCDV.Substring(0, 4) == "5641" || CCDV.Substring(0, 4) == "6333" || CCDV.Substring(0, 4) == "6759" || CCDV.Substring(0, 4) == "6334" || CCDV.Substring(0, 4) == "6767") && CCDV.Length == 13)
                            {
                                TipoBanco = ", Switch";
                            }
                            else
                            {
                                TipoBanco = ", Desconhecido";
                            }
                        }
                        sb.Append(TipoBanco);
                    }

                    sb.Append(Environment.NewLine);
                }
                txtCCGerado.Text = sb.ToString();
                txtCCGerado.Text = txtCCGerado.Text.Trim();
            }
            else if (cboxChecker.SelectedIndex == 2)
            {
                sb.Append("<xml>" + Environment.NewLine);
                for (int i = 0; i < QuantidadeCC.Value; i++)
                {
                    string CC = "";

                    int CCBinLength = CCBin.Length - 1;
                    for (int j = 0; j < CCBinLength; j++)
                    {
                        if (CCBin[j].ToString().ToUpper() == "X")
                        {
                            CC += (rnd.Next(0, 10));
                        }
                        else if (CCBin[j].ToString().ToUpper() == "M")
                        {
                            CC += (rnd.Next(1, 6));
                        }
                        else if (CCBin[j].ToString().ToUpper() == "A")
                        {
                            if (rnd.Next(1, 3) == 1)
                            {
                                CC += 4;
                            }
                            else
                            {
                                CC += 7;
                            }
                        }
                        else
                        {
                            CC += (CCBin[j]);
                        }
                    }

                    int Soma = 0, a = 0, d;
                    for (int j = CC.Length; j > 0; j--)
                    {
                        d = int.Parse(CC.Substring(j - 1, 1));
                        if (a % 2 == 0)
                        {
                            d *= 2;
                        }
                        if (d > 9)
                        {
                            d -= 9;
                        }
                        Soma += d;
                        a++;
                    }

                    int DV = 10 - (Soma % 10);
                    if (DV == 10)
                    {
                        DV = 0;
                    }

                    sb.Append("<CreditCard>" + Environment.NewLine);
                    if (checkTipobanco.Checked)
                    {
                        sb.Append("<CardNetwork>");
                        string TipoBanco = "";
                        string CCDV = CC + DV;
                        for (int j = 0; j < BinsPreDefinidos.Length; j++)
                        {
                            if (CCBIN.Substring(0, 6) == BinsPreDefinidos[j].Trim().Replace(" ", "").Replace("X", ""))
                            {
                                TipoBanco = cboxBins.Items[j + 1].ToString();
                                j = BinsPreDefinidos.Length;
                            }
                        }
                        if (TipoBanco == "")
                        {
                            if (CCDV.Substring(0, 1) == "4" && (CCDV.Length == 13 || CCDV.Length == 16))
                            {
                                TipoBanco = "Visa";
                            }
                            else if ((CCDV.Substring(0, 2) == "51" || CCDV.Substring(0, 2) == "52" || CCDV.Substring(0, 2) == "53" || CCDV.Substring(0, 2) == "54" || CCDV.Substring(0, 2) == "55") && CCDV.Length == 16)
                            {
                                TipoBanco = "Mastercard";
                            }
                            else if ((CCDV.Substring(0, 2) == "34" || CCDV.Substring(0, 2) == "37") && CCDV.Length == 15)
                            {
                                TipoBanco = "American Express";
                            }
                            else if (CCDV.Substring(0, 4) == "6011" && CCDV.Length == 16)
                            {
                                TipoBanco = "Discover";
                            }
                            else if ((CCDV.Substring(0, 4) == "3528" || CCDV.Substring(0, 4) == "3088" || CCDV.Substring(0, 4) == "3096" || CCDV.Substring(0, 4) == "3112" || CCDV.Substring(0, 4) == "3158" || CCDV.Substring(0, 4) == "3096" || CCDV.Substring(0, 4) == "3337") && CCDV.Length == 16)
                            {
                                TipoBanco = "JCB";
                            }
                            else if ((CCDV.Substring(0, 2) == "30" || CCDV.Substring(0, 2) == "36" || CCDV.Substring(0, 2) == "38") && (CCDV.Length == 14 || CCDV.Length == 16))
                            {
                                TipoBanco = "Diners Club";
                            }
                            else if ((CCDV.Substring(0, 4) == "2014" || CCDV.Substring(0, 4) == "2149") && CCDV.Length == 15)
                            {
                                TipoBanco = "enRoute";
                            }
                            else if (CCDV.Substring(0, 6) == "606282" && (CCDV.Length == 13 || CCDV.Length == 16 || CCDV.Length == 19))
                            {
                                TipoBanco = "Hipercard";
                            }
                            else if ((CCDV.Substring(0, 6) == "636368" || CCDV.Substring(0, 6) == "636369" || CCDV.Substring(0, 6) == "438935" || CCDV.Substring(0, 6) == "504175" || CCDV.Substring(0, 6) == "451416" || CCDV.Substring(0, 6) == "636297" || CCDV.Substring(0, 4) == "5067" || CCDV.Substring(0, 4) == "4576" || CCDV.Substring(0, 4) == "4011" || CCDV.Substring(0, 6) == "506699") && CCDV.Length == 16)
                            {
                                TipoBanco = "Elo";
                            }
                            else if (CCDV.Substring(0, 2) == "50" && CCDV.Length == 16)
                            {
                                TipoBanco = "Aura";
                            }
                            else if ((CCDV.Substring(0, 4) == "4903" || CCDV.Substring(0, 4) == "4911" || CCDV.Substring(0, 4) == "4936" || CCDV.Substring(0, 4) == "5641" || CCDV.Substring(0, 4) == "6333" || CCDV.Substring(0, 4) == "6759" || CCDV.Substring(0, 4) == "6334" || CCDV.Substring(0, 4) == "6767") && CCDV.Length == 13)
                            {
                                TipoBanco = "Switch";
                            }
                            else
                            {
                                TipoBanco = "Desconhecido";
                            }
                        }
                        sb.Append(TipoBanco + "</CardNetwork>" + Environment.NewLine);
                    }

                    sb.Append("<CardNumber>");

                    sb.Append(CC + DV);

                    sb.Append("</CardNumber>");


                    if (checkCVV.Checked)
                    {
                        string CVV;
                        if (txtCVV.Text.ToLower() == "rnd")
                        {
                            if ((CC.Substring(0, 2) == "37" || CC.Substring(0, 2) == "34") && CC.Length + 1 == 15)
                            {
                                CVV = rnd.Next(1000, 9999).ToString();
                            }
                            else if (CC.Substring(0, 4) == "6011" && CC.Length + 1 == 16)
                            {
                                CVV = rnd.Next(1000, 9999).ToString();
                            }
                            else
                            {
                                CVV = rnd.Next(101, 999).ToString();
                            }
                        }
                        else
                        {
                            CVV = txtCVV.Text;
                        }

                        sb.Append(Environment.NewLine + "<CardCVV>" + CVV + "</CardCVV>");
                    }
                    if (checkData.Checked)
                    {
                        string Mes;
                        if (cboxMes.SelectedIndex == 0)
                        {
                            Mes = rnd.Next(1, 13).ToString();
                        }
                        else
                        {
                            Mes = cboxMes.Text;
                        }

                        if (Mes.Length == 1)
                        {
                            Mes = "0" + Mes;
                        }

                        Mes = Mes + "/";

                        string Ano;
                        if (cboxAno.SelectedIndex == 0)
                        {
                            Ano = rnd.Next(2018, 2026).ToString();
                        }
                        else
                        {
                            Ano = cboxAno.Text;
                        }

                        if (Ano.Length == 2)
                        {
                            Ano = "20" + Ano;
                        }



                        sb.Append(Environment.NewLine + "<CardExpDate>" + Mes + Ano + "</CardExpDate>");
                    }
                    sb.Append(Environment.NewLine + "</CreditCard>" + Environment.NewLine);
                }
                sb.Append("</xml>");
                txtCCGerado.Text = sb.ToString();
                txtCCGerado.Text = txtCCGerado.Text.Trim();
            }
            else
            {
                sb.Append("{" + Environment.NewLine);
                for (int i = 0; i < QuantidadeCC.Value; i++)
                {
                    string CC = "";

                    int CCBinLength = CCBin.Length - 1;
                    for (int j = 0; j < CCBinLength; j++)
                    {
                        if (CCBin[j].ToString().ToUpper() == "X")
                        {
                            CC += (rnd.Next(0, 10));
                        }
                        else if (CCBin[j].ToString().ToUpper() == "M")
                        {
                            CC += (rnd.Next(1, 6));
                        }
                        else if (CCBin[j].ToString().ToUpper() == "A")
                        {
                            if (rnd.Next(1, 3) == 1)
                            {
                                CC += 4;
                            }
                            else
                            {
                                CC += 7;
                            }
                        }
                        else
                        {
                            CC += (CCBin[j]);
                        }
                    }

                    int Soma = 0, a = 0, d;
                    for (int j = CC.Length; j > 0; j--)
                    {
                        d = int.Parse(CC.Substring(j - 1, 1));
                        if (a % 2 == 0)
                        {
                            d *= 2;
                        }
                        if (d > 9)
                        {
                            d -= 9;
                        }
                        Soma += d;
                        a++;
                    }

                    int DV = 10 - (Soma % 10);
                    if (DV == 10)
                    {
                        DV = 0;
                    }

                    sb.Append("{" + Environment.NewLine + "\"CreditCard\":{" + Environment.NewLine);

                    if (checkTipobanco.Checked)
                    {
                        string CCDV = CC + DV;
                        sb.Append("\"CardNetwork\": ");
                        string TipoBanco = "";
                        for (int j = 0; j < BinsPreDefinidos.Length; j++)
                        {
                            if (CCBIN.Substring(0, 6) == BinsPreDefinidos[j].Trim().Replace(" ", "").Replace("X", ""))
                            {
                                TipoBanco = "\"" + cboxBins.Items[j + 1].ToString() + "\"";
                                j = BinsPreDefinidos.Length;
                            }
                        }
                        if (TipoBanco == "")
                        {
                            if (CCDV.Substring(0, 1) == "4" && (CCDV.Length == 13 || CCDV.Length == 16))
                            {
                                TipoBanco = "\"Visa\"";
                            }
                            else if ((CCDV.Substring(0, 2) == "51" || CCDV.Substring(0, 2) == "52" || CCDV.Substring(0, 2) == "53" || CCDV.Substring(0, 2) == "54" || CCDV.Substring(0, 2) == "55") && CCDV.Length == 16)
                            {
                                TipoBanco = "\"Mastercard\"";
                            }
                            else if ((CCDV.Substring(0, 2) == "34" || CCDV.Substring(0, 2) == "37") && CCDV.Length == 15)
                            {
                                TipoBanco = "\"American Express\"";
                            }
                            else if (CCDV.Substring(0, 4) == "6011" && CCDV.Length == 16)
                            {
                                TipoBanco = "\"Discover\"";
                            }
                            else if ((CCDV.Substring(0, 4) == "3528" || CCDV.Substring(0, 4) == "3088" || CCDV.Substring(0, 4) == "3096" || CCDV.Substring(0, 4) == "3112" || CCDV.Substring(0, 4) == "3158" || CCDV.Substring(0, 4) == "3096" || CCDV.Substring(0, 4) == "3337") && CCDV.Length == 16)
                            {
                                TipoBanco = "\"JCB\"";
                            }
                            else if ((CCDV.Substring(0, 2) == "30" || CCDV.Substring(0, 2) == "36" || CCDV.Substring(0, 2) == "38") && (CCDV.Length == 14 || CCDV.Length == 16))
                            {
                                TipoBanco = "\"Diners Club\"";
                            }
                            else if ((CCDV.Substring(0, 4) == "2014" || CCDV.Substring(0, 4) == "2149") && CCDV.Length == 15)
                            {
                                TipoBanco = "\"enRoute\"";
                            }
                            else if (CCDV.Substring(0, 6) == "606282" && (CCDV.Length == 13 || CCDV.Length == 16 || CCDV.Length == 19))
                            {
                                TipoBanco = "\"Hipercard\"";
                            }
                            else if ((CCDV.Substring(0, 6) == "636368" || CCDV.Substring(0, 6) == "636369" || CCDV.Substring(0, 6) == "438935" || CCDV.Substring(0, 6) == "504175" || CCDV.Substring(0, 6) == "451416" || CCDV.Substring(0, 6) == "636297" || CCDV.Substring(0, 4) == "5067" || CCDV.Substring(0, 4) == "4576" || CCDV.Substring(0, 4) == "4011" || CCDV.Substring(0, 6) == "506699") && CCDV.Length == 16)
                            {
                                TipoBanco = "\"Elo\"";
                            }
                            else if (CCDV.Substring(0, 2) == "50" && CCDV.Length == 16)
                            {
                                TipoBanco = "\"Aura\"";
                            }
                            else if ((CCDV.Substring(0, 4) == "4903" || CCDV.Substring(0, 4) == "4911" || CCDV.Substring(0, 4) == "4936" || CCDV.Substring(0, 4) == "5641" || CCDV.Substring(0, 4) == "6333" || CCDV.Substring(0, 4) == "6759" || CCDV.Substring(0, 4) == "6334" || CCDV.Substring(0, 4) == "6767") && CCDV.Length == 13)
                            {
                                TipoBanco = "\"Switch\"";
                            }
                            else
                            {
                                TipoBanco = "Desconhecido";
                            }
                        }
                        sb.Append(TipoBanco + Environment.NewLine);
                    }
                    sb.Append("\"CardNumber\": ");

                    sb.Append("\"" + CC + DV + "\"");

                    if (checkCVV.Checked)
                    {
                        string CVV;
                        if (txtCVV.Text.ToLower() == "rnd")
                        {
                            if ((CC.Substring(0, 2) == "37" || CC.Substring(0, 2) == "34") && CC.Length + 1 == 15)
                            {
                                CVV = rnd.Next(1000, 9999).ToString();
                            }
                            else if (CC.Substring(0, 4) == "6011" && CC.Length + 1 == 16)
                            {
                                CVV = rnd.Next(1000, 9999).ToString();
                            }
                            else
                            {
                                CVV = rnd.Next(101, 999).ToString();
                            }
                        }
                        else
                        {
                            CVV = txtCVV.Text;
                        }

                        sb.Append(Environment.NewLine + "\"CardCVV\": \"" + CVV + "\"");
                    }
                    if (checkData.Checked)
                    {
                        string Mes;
                        if (cboxMes.SelectedIndex == 0)
                        {
                            Mes = rnd.Next(1, 13).ToString();
                        }
                        else
                        {
                            Mes = cboxMes.Text;
                        }

                        if (Mes.Length == 1)
                        {
                            Mes = "0" + Mes;
                        }

                        Mes = Mes + "/";

                        string Ano;
                        if (cboxAno.SelectedIndex == 0)
                        {
                            Ano = rnd.Next(2018, 2026).ToString();
                        }
                        else
                        {
                            Ano = cboxAno.Text;
                        }

                        if (Ano.Length == 2)
                        {
                            Ano = "20" + Ano;
                        }

                        sb.Append(Environment.NewLine + "\"CardExpDate\": \"" + Mes + Ano + "\"");
                    }
                    sb.Append(Environment.NewLine + "}");
                    if (i == QuantidadeCC.Value - 1)
                    {
                        sb.Append(Environment.NewLine + "}");
                    }
                    else
                    {
                        sb.Append(Environment.NewLine + "}," + Environment.NewLine);
                    }
                }
                sb.Append(Environment.NewLine + "}");
                txtCCGerado.Text = sb.ToString();
                txtCCGerado.Text = txtCCGerado.Text.Trim();
            }
            return CC;
        }
