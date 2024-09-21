## Development

1. Install BepInEx
2. Create a file called `Environment.props` in the root folder (one folder above the Shields.csproj file) and add the following content:
   ```xml
   <?xml version="1.0" encoding="utf-8"?>
   <Project ToolsVersion="Current" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
       <PropertyGroup>
           <BELOW_THE_STONE_INSTALL>C:/Program Files/Steam/steamapps/common/Below The Stone</BELOW_THE_STONE_INSTALL>
           <R2MM_PROFILE>$(APPDATA)/r2modmanPlus/BelowTheStone/profiles/Default</R2MM_PROFILE>
           <BEPINEX_PATH>$(R2MM_PROFILE)/BepInEx</BEPINEX_PATH>
           <MOD_DEPLOYPATH>$(BELOW_THE_STONE_INSTALL)/BepInEx/plugins</MOD_DEPLOYPATH>
       </PropertyGroup>
   </Project>
   ```
3. Compile the project. This copies the resulting dll into the `MOD_DEPLOYPATH`, if set
4. To change assets, open the Unity project and adjust the files. Afterwards, open the Asset Bundle Browser and rebuild the asset bundle. When compiling the project, the asset bundle will be copied into the project folder
