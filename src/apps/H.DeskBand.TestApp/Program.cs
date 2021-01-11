﻿using System.Threading;
using System.Windows.Forms;
using H.DeskBand.TestApp;

var thread = new Thread(() =>
{
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run(new MainForm());
});
thread.SetApartmentState(ApartmentState.STA);
thread.Start();