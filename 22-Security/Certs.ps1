<# 
    Open this with administrator privileges

#>
cd "C:\Program Files (x86)\Windows Kits\10\bin\10.0.16299.0\x64"
.\makecert -sv "d:\abckey.pvk" -r -n "CN=ABC Coop" "d:\abccoop.cer"
.\cert2spc.exe "d:\abccoop.cer" "d:\abccoop.spc"
.\pvk2pfx.exe -pvk "d:\abckey.pvk" -spc "d:\abccoop.spc" -pfx "d:\abccoop.pfx"
.\signtool.exe sign -f "d:\abccoop.pfx" -v "D:\Development\DCoates\Domaine-de-Pratique\Prof CSharp5\bin\Release\ConsoleA1.exe"
.\signtool.exe verify -f "d:\abccoop.pfx" -v -a "D:\Development\DCoates\Domaine-de-Pratique\Prof CSharp5\bin\Release\ConsoleA1.exe"