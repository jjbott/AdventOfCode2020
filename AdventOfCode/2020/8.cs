﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    public class _8
    {
        

        public void RunA()
        {
            var program = input.Split("\r\n").Select(l => l.Split(" ")).ToArray();

            var visited = new HashSet<int>();
            var pc = 0;
            var acc = 0;
            while(!visited.Contains(pc))
            {
                visited.Add(pc);

                var instruction = program[pc];
                Console.WriteLine($"{pc} {acc} {instruction[0]} {instruction[1]}");
                switch(instruction[0])
                {
                    case "nop":
                        ++pc;
                        break;
                    case "acc":
                        acc += int.Parse(instruction[1]);
                        ++pc;
                        break;
                    case "jmp":
                        pc += int.Parse(instruction[1]);
                        break;
                }
            }
            Console.WriteLine(acc);
        }

        public int? RunProgramUntilExit(string[][] program)
        {
            var visited = new HashSet<int>();
            var pc = 0;
            var acc = 0;
            while (!visited.Contains(pc) && pc < program.Length && pc >= 0)
            {
                visited.Add(pc);

                var instruction = program[pc];
                //Console.WriteLine($"{pc} {acc} {instruction[0]} {instruction[1]}");
                switch (instruction[0])
                {
                    case "nop":
                        ++pc;
                        break;
                    case "acc":
                        acc += int.Parse(instruction[1]);
                        ++pc;
                        break;
                    case "jmp":
                        pc += int.Parse(instruction[1]);
                        break;
                }
            }

            if (pc == program.Length)
            {
                return acc;
            }
            return null;
        }

        public void RunB()
        {
            var program = input.Split("\r\n").Select(l => l.Split(" ")).ToArray();
            for(int i = 0; i < program.Length; ++i )
            {
                Console.WriteLine(i);
                var originalInstruction = program[i][0];
                if (originalInstruction == "nop")
                {
                    program[i][0] = "jmp";
                }
                else if (originalInstruction == "jmp")
                {
                    program[i][0] = "nop";
                }
                else
                {
                    continue;
                }

                var result = RunProgramUntilExit(program);
                if ( result.HasValue )
                {
                    Console.WriteLine(result);
                    //break;
                }

                program[i][0] = originalInstruction;
            }
        }
        private string input = @"jmp +149
acc -11
nop +95
acc -6
jmp +196
acc +2
acc -6
acc +38
acc +18
jmp +246
acc +43
acc +37
acc -1
jmp +390
acc +32
acc -15
jmp +487
jmp +382
jmp +71
jmp +331
acc -3
acc -12
acc +4
jmp +417
acc +30
acc +20
jmp +410
acc +22
acc +25
acc +19
acc +5
jmp +405
acc +15
acc +33
acc +7
acc -18
jmp +463
acc +25
acc +8
acc +1
jmp +64
jmp +1
jmp +562
jmp +4
acc +21
acc +12
jmp +467
nop +197
acc +32
jmp +7
acc +2
jmp +352
acc +15
jmp +289
acc +39
jmp +448
jmp +227
acc +17
acc +4
jmp +326
acc -1
nop +167
acc +30
nop +471
jmp +101
acc +45
nop +276
acc +12
jmp +215
nop +80
acc +23
acc +31
jmp +104
acc +39
acc +15
jmp +40
nop +433
acc +21
acc +22
acc +37
jmp +421
acc +14
jmp -30
acc +42
acc +38
jmp +203
acc -8
acc +27
jmp +102
acc -5
acc +0
acc +18
acc +26
jmp +212
acc +25
acc +18
jmp +209
acc +18
acc +44
acc +47
nop -40
jmp +372
acc +29
jmp +384
acc +39
acc -11
acc +43
jmp +406
acc +2
nop +439
jmp +343
acc +29
acc +18
jmp +457
jmp -31
jmp +146
acc +12
acc +26
nop +98
jmp +125
acc +6
acc +35
acc +48
acc +44
jmp +497
acc +17
acc -8
jmp +223
acc +47
jmp +405
jmp +212
jmp +317
acc -13
acc -6
jmp +94
acc +47
acc +50
acc -16
acc +38
jmp +290
jmp +383
nop -44
acc +38
nop +418
acc +42
jmp +233
nop -94
acc +46
jmp +413
acc +10
acc -6
jmp +410
acc +30
jmp -93
acc -13
jmp +6
acc -16
acc +18
nop +403
acc +0
jmp +68
acc +45
jmp +302
acc +5
jmp +26
acc -5
acc +49
jmp +412
acc +3
acc +14
jmp +278
acc +6
acc +4
jmp -58
acc +14
jmp -60
acc -12
acc +23
jmp +225
acc +9
acc +17
acc -10
acc -13
jmp +216
acc -8
nop +363
jmp +84
nop +300
acc -15
jmp +415
acc +17
acc -11
nop +96
jmp +377
nop +259
acc +4
jmp +327
acc +0
jmp +149
jmp +12
acc +23
acc +43
acc +2
jmp +1
jmp +400
acc +24
jmp +114
acc +3
acc -13
jmp +149
jmp +100
jmp +1
jmp +157
acc +23
acc -15
jmp -139
nop -85
jmp +201
acc -2
acc +39
acc +30
nop -93
jmp -11
acc +46
jmp +285
jmp +1
acc +41
jmp +115
acc +48
acc -12
acc -17
jmp -15
nop +82
acc +25
jmp -151
acc +20
acc -14
acc +9
acc -9
jmp +284
acc +27
acc +38
acc +50
jmp +145
nop +279
jmp -55
nop +245
jmp +254
acc +4
jmp +368
nop -119
acc -11
acc +16
acc +19
jmp -54
nop -186
nop -187
acc +9
acc +44
jmp -222
jmp +253
nop -234
acc +33
acc +35
acc -17
jmp +11
acc +2
acc +41
acc +47
jmp +310
acc +0
acc -8
acc +1
jmp +55
acc -1
jmp -257
acc +7
acc +44
nop +253
acc +41
jmp +302
acc +16
jmp -185
jmp +140
jmp +1
nop +3
acc +35
jmp -267
acc +6
jmp -269
jmp +211
acc +30
acc +14
acc +16
acc +41
jmp -47
jmp -192
nop -21
acc -1
jmp +192
acc -6
acc +15
acc +3
nop -247
jmp -88
jmp +164
acc +47
nop +43
acc +40
jmp +151
jmp +85
jmp +1
acc +40
jmp -257
acc +13
acc +13
jmp -256
acc +25
acc +39
jmp +260
acc +13
acc -18
acc -19
acc -14
jmp -10
acc -16
acc +9
jmp -199
nop +185
acc +38
jmp -261
nop +200
acc -18
nop +115
acc +36
jmp -259
acc +47
acc -2
acc +9
jmp -139
nop -117
jmp -13
jmp +1
jmp +247
acc +19
acc +49
jmp +177
acc -1
jmp +249
jmp -218
acc +12
acc +33
jmp +108
jmp -48
nop -205
acc +32
jmp -159
jmp -129
acc +32
jmp +1
jmp +249
nop +75
acc +17
acc -16
jmp +253
acc -9
jmp -12
acc +15
jmp -14
acc +13
acc -8
nop -13
jmp +27
nop -336
acc +33
acc +10
acc -1
jmp -350
nop -134
acc -11
jmp +5
acc +10
acc +13
acc +13
jmp -249
acc +8
jmp -215
jmp +49
acc +35
acc +28
jmp -54
acc +14
nop -264
jmp +1
jmp -166
jmp -291
acc +9
acc +43
jmp -301
nop +149
acc -9
jmp -81
jmp -287
acc +9
acc +35
acc -12
jmp -295
acc +46
jmp -394
acc +29
acc +19
acc +9
jmp -58
acc +7
acc +32
nop -261
acc +44
jmp -365
jmp +1
jmp +120
acc +37
nop -177
jmp +101
acc +42
acc +13
acc +36
jmp -343
acc +45
jmp -408
acc +23
acc +0
jmp -66
jmp +1
acc +34
acc +19
jmp +104
jmp +1
acc +36
jmp -141
jmp -44
acc +9
acc +30
acc +18
acc +0
jmp -303
jmp +1
acc +12
jmp +66
acc +0
jmp +82
acc +43
acc +18
jmp +49
acc -16
acc -3
acc +0
jmp -249
acc -2
nop +81
jmp +40
jmp +94
acc -16
acc +1
jmp -445
jmp +1
acc +22
jmp -130
acc +44
jmp -73
acc +3
acc +5
jmp -121
jmp -352
jmp -163
acc +15
acc +47
nop +141
jmp +140
acc -18
nop -289
acc +16
jmp -476
acc -19
nop +134
acc -10
acc +37
jmp -13
jmp -359
acc +32
acc +14
jmp -306
acc +25
acc +30
jmp -441
acc +44
acc +14
acc +12
acc +19
jmp -387
jmp -12
jmp -180
jmp -113
jmp -29
acc +34
acc -13
acc -12
nop +73
jmp -263
jmp -373
jmp -360
acc +38
nop -123
jmp -176
nop -155
acc -11
acc +32
nop +54
jmp -461
acc +31
acc +10
acc -7
acc -19
jmp -212
acc +41
acc +4
nop -2
jmp -483
acc +16
acc +42
acc -15
jmp -286
jmp -122
acc -4
jmp -436
acc +27
jmp -508
acc +38
nop -309
jmp +10
acc +31
acc +18
acc +5
jmp -119
acc +8
acc -7
acc -16
acc +18
jmp -416
acc -15
acc +1
acc +30
acc +8
jmp -476
jmp -298
acc +29
acc +24
acc -9
acc +35
jmp -438
nop -5
jmp -100
acc +5
acc +3
acc +5
acc -4
jmp +14
acc +43
acc +3
acc +40
jmp -517
acc +10
acc +35
acc +38
jmp -120
acc +1
acc -18
acc +0
acc +42
jmp -69
jmp -101
acc +1
jmp -271
acc +37
acc +17
jmp +1
jmp -401
acc +1
acc +3
acc -8
jmp -392
nop -99
acc +2
jmp -301
acc +10
acc +32
acc +3
jmp -286
jmp +1
jmp -444
nop -364
acc +46
acc +30
acc -2
jmp -13
nop -65
acc +22
jmp -292
acc -13
jmp -480
acc +4
acc -8
nop -500
jmp -113
acc -16
acc +40
acc -18
jmp -125
jmp -482
acc +28
acc -5
jmp -471
acc +33
acc +49
acc +21
acc +9
jmp +1";
    }
}
