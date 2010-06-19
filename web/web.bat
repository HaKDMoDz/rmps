:: Remove all Eclipse's config files.
rmdir .settings /s /q
del .project /s /f

:: Remove all Amon's description files.
del *.wvp /s /q /f


:: Remove .net Envirement directory
rmdir aspnet_client /s /q

:: Remove folder: asun
rmdir asun /s /q
:: Remove folder: blog
rmdir blog /s /q

:: Remove folder: card\data
cd card
cd data
del * /s /q
cd..
cd..

:: Remove folder: code
rmdir code /s /q
:: Remove folder: data
rmdir data /s /q

:: Remove folder: edit\file
cd edit
rmdir file /s /q
cd ..

:: Remove folder: exts\history
cd exts
rmdir history /s /q
del AC_OETags.js /f
del exts0001.html /f
cd ..

:: Remove folder: flex
rmdir flex /s /q
:: Remove folder: ibbs
rmdir ibbs /s /q

:: Remove folder: icon
cd icon

cd img
del * /q /f
cd ..

cd res
del * /q /f
cd ..

cd svg
del * /q /f
cd ..

cd ..

:: Remove folder: inet
cd inet
cd c
del NetHelper.htm /f
del test.htm /f
del test.js /f
cd ..
cd ..

:: Remove folder: jnlp
cd jnlp
del magicpwd.jar /f
del magicpwd.jnlp /f
del rmps.cer /f
del rmps.cst /f
cd ..

:: Remove folder: srch
cd srch
cd c
del iSearcher.htm /q /f
cd ..
cd ..

:: Remove folder: temp
cd temp
del * /s /q /f
cd ..

:: Remove folder: Templates
rmdir Templates /s /q

:: Remove folder: wime
cd wime
cd c
del wime.htm /q /f
cd ..
cd ..