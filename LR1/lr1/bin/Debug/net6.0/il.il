
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0




// Metadata version: v4.0.30319
.assembly extern System.Runtime
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 6:0:0:0
}
.assembly extern System.Console
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 6:0:0:0
}
.assembly extern System.Linq
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 6:0:0:0
}
.assembly lr1
{
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                                   63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- Следующий настраиваемый атрибут добавлен автоматически, не следует отменять преобразование в комментарий -------
  //  .custom instance void [System.Runtime]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [System.Runtime]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .custom instance void [System.Runtime]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = ( 01 00 18 2E 4E 45 54 43 6F 72 65 41 70 70 2C 56   // ....NETCoreApp,V
                                                                                                              65 72 73 69 6F 6E 3D 76 36 2E 30 01 00 54 0E 14   // ersion=v6.0..T..
                                                                                                              46 72 61 6D 65 77 6F 72 6B 44 69 73 70 6C 61 79   // FrameworkDisplay
                                                                                                              4E 61 6D 65 00 )                                  // Name.
  .custom instance void [System.Runtime]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 03 6C 72 31 00 00 )                         // ...lr1..
  .custom instance void [System.Runtime]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 05 44 65 62 75 67 00 00 )                   // ...Debug..
  .custom instance void [System.Runtime]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void [System.Runtime]System.Reflection.AssemblyInformationalVersionAttribute::.ctor(string) = ( 01 00 05 31 2E 30 2E 30 00 00 )                   // ...1.0.0..
  .custom instance void [System.Runtime]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 03 6C 72 31 00 00 )                         // ...lr1..
  .custom instance void [System.Runtime]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 03 6C 72 31 00 00 )                         // ...lr1..
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module lr1.dll
// MVID: {368D42E2-A0E1-42FC-9F2F-B4C177A211C0}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x06BE0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi sealed beforefieldinit Microsoft.CodeAnalysis.EmbeddedAttribute
       extends [System.Runtime]System.Attribute
{
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void Microsoft.CodeAnalysis.EmbeddedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Размер кода:       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [System.Runtime]System.Attribute::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method EmbeddedAttribute::.ctor

} // end of class Microsoft.CodeAnalysis.EmbeddedAttribute

.class private auto ansi sealed beforefieldinit System.Runtime.CompilerServices.NullableAttribute
       extends [System.Runtime]System.Attribute
{
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void Microsoft.CodeAnalysis.EmbeddedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [System.Runtime]System.AttributeUsageAttribute::.ctor(valuetype [System.Runtime]System.AttributeTargets) = ( 01 00 84 6B 00 00 02 00 54 02 0D 41 6C 6C 6F 77   // ...k....T..Allow
                                                                                                                                     4D 75 6C 74 69 70 6C 65 00 54 02 09 49 6E 68 65   // Multiple.T..Inhe
                                                                                                                                     72 69 74 65 64 00 )                               // rited.
  .field public initonly uint8[] NullableFlags
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(uint8 A_1) cil managed
  {
    // Размер кода:       24 (0x18)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [System.Runtime]System.Attribute::.ctor()
    IL_0006:  nop
    IL_0007:  ldarg.0
    IL_0008:  ldc.i4.1
    IL_0009:  newarr     [System.Runtime]System.Byte
    IL_000e:  dup
    IL_000f:  ldc.i4.0
    IL_0010:  ldarg.1
    IL_0011:  stelem.i1
    IL_0012:  stfld      uint8[] System.Runtime.CompilerServices.NullableAttribute::NullableFlags
    IL_0017:  ret
  } // end of method NullableAttribute::.ctor

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(uint8[] A_1) cil managed
  {
    // Размер кода:       15 (0xf)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [System.Runtime]System.Attribute::.ctor()
    IL_0006:  nop
    IL_0007:  ldarg.0
    IL_0008:  ldarg.1
    IL_0009:  stfld      uint8[] System.Runtime.CompilerServices.NullableAttribute::NullableFlags
    IL_000e:  ret
  } // end of method NullableAttribute::.ctor

} // end of class System.Runtime.CompilerServices.NullableAttribute

.class private auto ansi sealed beforefieldinit System.Runtime.CompilerServices.NullableContextAttribute
       extends [System.Runtime]System.Attribute
{
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void Microsoft.CodeAnalysis.EmbeddedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [System.Runtime]System.AttributeUsageAttribute::.ctor(valuetype [System.Runtime]System.AttributeTargets) = ( 01 00 4C 14 00 00 02 00 54 02 0D 41 6C 6C 6F 77   // ..L.....T..Allow
                                                                                                                                     4D 75 6C 74 69 70 6C 65 00 54 02 09 49 6E 68 65   // Multiple.T..Inhe
                                                                                                                                     72 69 74 65 64 00 )                               // rited.
  .field public initonly uint8 Flag
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(uint8 A_1) cil managed
  {
    // Размер кода:       15 (0xf)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [System.Runtime]System.Attribute::.ctor()
    IL_0006:  nop
    IL_0007:  ldarg.0
    IL_0008:  ldarg.1
    IL_0009:  stfld      uint8 System.Runtime.CompilerServices.NullableContextAttribute::Flag
    IL_000e:  ret
  } // end of method NullableContextAttribute::.ctor

} // end of class System.Runtime.CompilerServices.NullableContextAttribute

.class private auto ansi beforefieldinit MenuItems
       extends [System.Runtime]System.Object
{
  .custom instance void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(uint8) = ( 01 00 01 00 00 ) 
  .custom instance void System.Runtime.CompilerServices.NullableAttribute::.ctor(uint8) = ( 01 00 00 00 00 ) 
  .class auto ansi sealed nested private MenuOption
         extends [System.Runtime]System.Enum
  {
    .custom instance void System.Runtime.CompilerServices.NullableContextAttribute::.ctor(uint8) = ( 01 00 00 00 00 ) 
    .field public specialname rtspecialname int32 value__
    .field public static literal valuetype MenuItems/MenuOption Invalid = int32(0x00000000)
    .field public static literal valuetype MenuItems/MenuOption DisplayWords = int32(0x00000001)
    .field public static literal valuetype MenuItems/MenuOption Addition = int32(0x00000002)
    .field public static literal valuetype MenuItems/MenuOption Exit = int32(0x00000003)
  } // end of class MenuOption

  .method private hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Размер кода:       170 (0xaa)
    .maxstack  2
    .locals init (bool V_0,
             int32 V_1,
             bool V_2,
             valuetype MenuItems/MenuOption V_3,
             valuetype MenuItems/MenuOption V_4,
             valuetype MenuItems/MenuOption V_5,
             bool V_6)
    IL_0000:  nop
    IL_0001:  ldc.i4.0
    IL_0002:  stloc.0
    IL_0003:  br         IL_009c

    IL_0008:  nop
    IL_0009:  ldstr      "Menu:\n\n1. Output the specified number of words fro"
    + "m the text.\n2. Perform a mathematical operation (addition).\n3. Exit.\n"
    IL_000e:  call       void [System.Console]System.Console::WriteLine(string)
    IL_0013:  nop
    IL_0014:  ldstr      "Select the menu item: "
    IL_0019:  call       void [System.Console]System.Console::Write(string)
    IL_001e:  nop
    IL_001f:  call       string [System.Console]System.Console::ReadLine()
    IL_0024:  ldloca.s   V_1
    IL_0026:  call       bool [System.Runtime]System.Int32::TryParse(string,
                                                                     int32&)
    IL_002b:  brfalse.s  IL_0044

    IL_002d:  ldtoken    MenuItems/MenuOption
    IL_0032:  call       class [System.Runtime]System.Type [System.Runtime]System.Type::GetTypeFromHandle(valuetype [System.Runtime]System.RuntimeTypeHandle)
    IL_0037:  ldloc.1
    IL_0038:  box        [System.Runtime]System.Int32
    IL_003d:  call       bool [System.Runtime]System.Enum::IsDefined(class [System.Runtime]System.Type,
                                                                     object)
    IL_0042:  br.s       IL_0045

    IL_0044:  ldc.i4.0
    IL_0045:  stloc.2
    IL_0046:  ldloc.2
    IL_0047:  brfalse.s  IL_008e

    IL_0049:  nop
    IL_004a:  ldloc.1
    IL_004b:  stloc.3
    IL_004c:  ldloc.3
    IL_004d:  stloc.s    V_5
    IL_004f:  ldloc.s    V_5
    IL_0051:  stloc.s    V_4
    IL_0053:  ldloc.s    V_4
    IL_0055:  ldc.i4.1
    IL_0056:  sub
    IL_0057:  switch     ( 
                          IL_006a,
                          IL_0072,
                          IL_007a)
    IL_0068:  br.s       IL_007e

    IL_006a:  call       void MenuItems::DisplayWords()
    IL_006f:  nop
    IL_0070:  br.s       IL_008b

    IL_0072:  call       void MenuItems::Addition()
    IL_0077:  nop
    IL_0078:  br.s       IL_008b

    IL_007a:  ldc.i4.1
    IL_007b:  stloc.0
    IL_007c:  br.s       IL_008b

    IL_007e:  ldstr      "Wrong choice. Try again.\n"
    IL_0083:  call       void [System.Console]System.Console::WriteLine(string)
    IL_0088:  nop
    IL_0089:  br.s       IL_008b

    IL_008b:  nop
    IL_008c:  br.s       IL_009b

    IL_008e:  nop
    IL_008f:  ldstr      "Wrong choice. Try again.\n"
    IL_0094:  call       void [System.Console]System.Console::WriteLine(string)
    IL_0099:  nop
    IL_009a:  nop
    IL_009b:  nop
    IL_009c:  ldloc.0
    IL_009d:  ldc.i4.0
    IL_009e:  ceq
    IL_00a0:  stloc.s    V_6
    IL_00a2:  ldloc.s    V_6
    IL_00a4:  brtrue     IL_0008

    IL_00a9:  ret
  } // end of method MenuItems::Main

  .method private hidebysig static void  DisplayWords() cil managed
  {
    // Размер кода:       178 (0xb2)
    .maxstack  3
    .locals init (string[] V_0,
             int32 V_1,
             bool V_2,
             bool V_3,
             bool V_4)
    IL_0000:  nop
    IL_0001:  ldstr      "Lorem ipsum.txt"
    IL_0006:  call       bool [System.Runtime]System.IO.File::Exists(string)
    IL_000b:  ldc.i4.0
    IL_000c:  ceq
    IL_000e:  stloc.2
    IL_000f:  ldloc.2
    IL_0010:  brfalse.s  IL_0029

    IL_0012:  nop
    IL_0013:  ldstr      "File not found.\n"
    IL_0018:  call       void [System.Console]System.Console::WriteLine(string)
    IL_001d:  nop
    IL_001e:  call       void MenuItems::Pause()
    IL_0023:  nop
    IL_0024:  br         IL_00b1

    IL_0029:  ldstr      "Lorem ipsum.txt"
    IL_002e:  call       string[] MenuItems::ReadFileWords(string)
    IL_0033:  stloc.0
    IL_0034:  ldloc.0
    IL_0035:  ldlen
    IL_0036:  ldc.i4.0
    IL_0037:  ceq
    IL_0039:  stloc.3
    IL_003a:  ldloc.3
    IL_003b:  brfalse.s  IL_0051

    IL_003d:  nop
    IL_003e:  ldstr      "The file is empty or contains incorrect data.\n"
    IL_0043:  call       void [System.Console]System.Console::WriteLine(string)
    IL_0048:  nop
    IL_0049:  call       void MenuItems::Pause()
    IL_004e:  nop
    IL_004f:  br.s       IL_00b1

    IL_0051:  ldstr      "\nEnter the number of words to display: "
    IL_0056:  call       void [System.Console]System.Console::Write(string)
    IL_005b:  nop
    IL_005c:  call       string [System.Console]System.Console::ReadLine()
    IL_0061:  ldloca.s   V_1
    IL_0063:  call       bool [System.Runtime]System.Int32::TryParse(string,
                                                                     int32&)
    IL_0068:  brfalse.s  IL_0070

    IL_006a:  ldloc.1
    IL_006b:  ldc.i4.0
    IL_006c:  cgt
    IL_006e:  br.s       IL_0071

    IL_0070:  ldc.i4.0
    IL_0071:  stloc.s    V_4
    IL_0073:  ldloc.s    V_4
    IL_0075:  brfalse.s  IL_009e

    IL_0077:  nop
    IL_0078:  ldloc.1
    IL_0079:  ldloc.0
    IL_007a:  ldlen
    IL_007b:  conv.i4
    IL_007c:  call       int32 [System.Runtime]System.Math::Min(int32,
                                                                int32)
    IL_0081:  ldc.i4.1
    IL_0082:  sub
    IL_0083:  stloc.1
    IL_0084:  ldstr      " "
    IL_0089:  ldloc.0
    IL_008a:  ldloc.1
    IL_008b:  call       class [System.Runtime]System.Collections.Generic.IEnumerable`1<!!0> [System.Linq]System.Linq.Enumerable::Take<string>(class [System.Runtime]System.Collections.Generic.IEnumerable`1<!!0>,
                                                                                                                                               int32)
    IL_0090:  call       string [System.Runtime]System.String::Join(string,
                                                                    class [System.Runtime]System.Collections.Generic.IEnumerable`1<string>)
    IL_0095:  call       void [System.Console]System.Console::WriteLine(string)
    IL_009a:  nop
    IL_009b:  nop
    IL_009c:  br.s       IL_00ab

    IL_009e:  nop
    IL_009f:  ldstr      "\nInvalid input. Enter the correct number."
    IL_00a4:  call       void [System.Console]System.Console::WriteLine(string)
    IL_00a9:  nop
    IL_00aa:  nop
    IL_00ab:  call       void MenuItems::Pause()
    IL_00b0:  nop
    IL_00b1:  ret
  } // end of method MenuItems::DisplayWords

  .method private hidebysig static string[] 
          ReadFileWords(string path) cil managed
  {
    // Размер кода:       60 (0x3c)
    .maxstack  3
    .locals init (string V_0,
             string[] V_1,
             class [System.Runtime]System.Exception V_2)
    IL_0000:  nop
    .try
    {
      IL_0001:  nop
      IL_0002:  ldarg.0
      IL_0003:  call       string [System.Runtime]System.IO.File::ReadAllText(string)
      IL_0008:  stloc.0
      IL_0009:  ldloc.0
      IL_000a:  ldc.i4.s   32
      IL_000c:  ldc.i4.1
      IL_000d:  callvirt   instance string[] [System.Runtime]System.String::Split(char,
                                                                                  valuetype [System.Runtime]System.StringSplitOptions)
      IL_0012:  stloc.1
      IL_0013:  leave.s    IL_003a

    }  // end .try
    catch [System.Runtime]System.Exception 
    {
      IL_0015:  stloc.2
      IL_0016:  nop
      IL_0017:  ldstr      "Exeption: "
      IL_001c:  ldloc.2
      IL_001d:  callvirt   instance string [System.Runtime]System.Exception::get_Message()
      IL_0022:  ldstr      "\n"
      IL_0027:  call       string [System.Runtime]System.String::Concat(string,
                                                                        string,
                                                                        string)
      IL_002c:  call       void [System.Console]System.Console::WriteLine(string)
      IL_0031:  nop
      IL_0032:  call       !!0[] [System.Runtime]System.Array::Empty<string>()
      IL_0037:  stloc.1
      IL_0038:  leave.s    IL_003a

    }  // end handler
    IL_003a:  ldloc.1
    IL_003b:  ret
  } // end of method MenuItems::ReadFileWords

  .method private hidebysig static void  Addition() cil managed
  {
    // Размер кода:       79 (0x4f)
    .maxstack  3
    .locals init (float64 V_0,
             float64 V_1,
             float64 V_2,
             valuetype [System.Runtime]System.Runtime.CompilerServices.DefaultInterpolatedStringHandler V_3)
    IL_0000:  nop
    IL_0001:  ldstr      "\nEnter the first number: "
    IL_0006:  call       float64 MenuItems::GetNumberFromUser(string)
    IL_000b:  stloc.0
    IL_000c:  ldstr      "Enter the second number: "
    IL_0011:  call       float64 MenuItems::GetNumberFromUser(string)
    IL_0016:  stloc.1
    IL_0017:  ldloc.0
    IL_0018:  ldloc.1
    IL_0019:  add
    IL_001a:  stloc.2
    IL_001b:  ldloca.s   V_3
    IL_001d:  ldc.i4.s   17
    IL_001f:  ldc.i4.1
    IL_0020:  call       instance void [System.Runtime]System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor(int32,
                                                                                                                               int32)
    IL_0025:  ldloca.s   V_3
    IL_0027:  ldstr      "Addition result: "
    IL_002c:  call       instance void [System.Runtime]System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral(string)
    IL_0031:  nop
    IL_0032:  ldloca.s   V_3
    IL_0034:  ldloc.2
    IL_0035:  call       instance void [System.Runtime]System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted<float64>(!!0)
    IL_003a:  nop
    IL_003b:  ldloca.s   V_3
    IL_003d:  call       instance string [System.Runtime]System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear()
    IL_0042:  call       void [System.Console]System.Console::WriteLine(string)
    IL_0047:  nop
    IL_0048:  call       void MenuItems::Pause()
    IL_004d:  nop
    IL_004e:  ret
  } // end of method MenuItems::Addition

  .method private hidebysig static float64 
          GetNumberFromUser(string prompt) cil managed
  {
    // Размер кода:       52 (0x34)
    .maxstack  2
    .locals init (float64 V_0,
             bool V_1,
             float64 V_2,
             bool V_3)
    IL_0000:  nop
    IL_0001:  br.s       IL_002e

    IL_0003:  nop
    IL_0004:  ldarg.0
    IL_0005:  call       void [System.Console]System.Console::Write(string)
    IL_000a:  nop
    IL_000b:  call       string [System.Console]System.Console::ReadLine()
    IL_0010:  ldloca.s   V_0
    IL_0012:  call       bool [System.Runtime]System.Double::TryParse(string,
                                                                      float64&)
    IL_0017:  stloc.1
    IL_0018:  ldloc.1
    IL_0019:  brfalse.s  IL_0020

    IL_001b:  nop
    IL_001c:  ldloc.0
    IL_001d:  stloc.2
    IL_001e:  br.s       IL_0032

    IL_0020:  nop
    IL_0021:  ldstr      "\nInvalid input. Enter the correct number."
    IL_0026:  call       void [System.Console]System.Console::WriteLine(string)
    IL_002b:  nop
    IL_002c:  nop
    IL_002d:  nop
    IL_002e:  ldc.i4.1
    IL_002f:  stloc.3
    IL_0030:  br.s       IL_0003

    IL_0032:  ldloc.2
    IL_0033:  ret
  } // end of method MenuItems::GetNumberFromUser

  .method private hidebysig static void  Pause() cil managed
  {
    // Размер кода:       20 (0x14)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldstr      "\nPress any key to continue.\n"
    IL_0006:  call       void [System.Console]System.Console::WriteLine(string)
    IL_000b:  nop
    IL_000c:  ldc.i4.1
    IL_000d:  call       valuetype [System.Console]System.ConsoleKeyInfo [System.Console]System.Console::ReadKey(bool)
    IL_0012:  pop
    IL_0013:  ret
  } // end of method MenuItems::Pause

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Размер кода:       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [System.Runtime]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method MenuItems::.ctor

} // end of class MenuItems


// =============================================================

// *********** ДИЗАССЕМБЛИРОВАНИЕ ЗАВЕРШЕНО ***********************
// ВНИМАНИЕ: создан файл ресурсов Win32 il.res
