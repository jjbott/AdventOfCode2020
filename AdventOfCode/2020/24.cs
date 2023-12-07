using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class _24
    {
        public void RunA()
        {
            var m = new Dictionary<(int x, int y), bool>();

            var lines = input.Split("\r\n");
            foreach(var l in lines)
            {
                var temp = l.Split("nw");
                var nw = temp.Length - 1;
                temp = string.Join("", temp).Split("sw");
                var sw = temp.Length - 1;
                temp = string.Join("", temp).Split("ne");
                var ne = temp.Length - 1;
                temp = string.Join("", temp).Split("se");
                var se = temp.Length - 1;
                temp = string.Join("", temp).Split("e");
                var e = temp.Length - 1;
                temp = string.Join("", temp).Split("w");
                var w = temp.Length - 1;

                int x = (e - w) + (ne-sw);
                int y = (se - nw) + (sw-ne);

                if  ( !m.ContainsKey((x,y)))
                {
                    m[(x, y)] = false;
                }

                m[(x, y)] = !m[(x, y)];
            }

            Console.WriteLine(m.Values.Where(v => v).Count());
        }

        private IEnumerable<(int x, int y)> Candidates(Dictionary<(int x, int y), bool> map)
        {
            foreach(var kv in map.Where(kv => kv.Value))
            {
                yield return kv.Key;
                yield return (kv.Key.x - 1, kv.Key.y + 1);
                yield return (kv.Key.x - 1, kv.Key.y);
                yield return (kv.Key.x , kv.Key.y + 1);
                yield return (kv.Key.x, kv.Key.y - 1 );
                yield return (kv.Key.x + 1, kv.Key.y - 1);
                yield return (kv.Key.x + 1, kv.Key.y);
            }
        }
        private bool MapValue(Dictionary<(int x, int y), bool> map, (int x, int y) coords)
        {
            return map.ContainsKey(coords) && map[coords];
        }

        private int BlackCount(Dictionary<(int x, int y), bool> map, (int x, int y) coords)
        {
            var count = 0;

            if (MapValue(map, (coords.x - 1, coords.y + 1))) count++;
            if (MapValue(map, (coords.x - 1, coords.y))) count++;
            if (MapValue(map, (coords.x, coords.y + 1))) count++;
            if (MapValue(map, (coords.x, coords.y - 1))) count++;
            if (MapValue(map, (coords.x + 1, coords.y - 1))) count++;
            if (MapValue(map, (coords.x + 1, coords.y))) count++;

            return count;
        }

        public void RunB()
        {
            //input = testcase;

            var m = new Dictionary<(int x, int y), bool>();

            var lines = input.Split("\r\n");
            foreach (var l in lines)
            {
                var temp = l.Split("nw");
                var nw = temp.Length - 1;
                temp = string.Join("", temp).Split("sw");
                var sw = temp.Length - 1;
                temp = string.Join("", temp).Split("ne");
                var ne = temp.Length - 1;
                temp = string.Join("", temp).Split("se");
                var se = temp.Length - 1;
                temp = string.Join("", temp).Split("e");
                var e = temp.Length - 1;
                temp = string.Join("", temp).Split("w");
                var w = temp.Length - 1;

                int x = (e - w) + (ne - sw);
                int y = (se - nw) + (sw - ne);

                if (!m.ContainsKey((x, y)))
                {
                    m[(x, y)] = false;
                }

                m[(x, y)] = !m[(x, y)];
            }

            for(int i = 0; i < 100; ++i)
            {
                var newMap = new Dictionary<(int x, int y), bool>();
                foreach(var c in Candidates(m))
                {
                    var count = BlackCount(m, c);
                    if ( MapValue(m, c) )
                    {
                        if ( count == 0 || count > 2)
                        {
                            newMap[c] = false;
                        }
                        else
                        {
                            newMap[c] = true;
                        }
                    }
                    else
                    {
                        if (count == 2)
                        {
                            newMap[c] = true;
                        }
                    }
                }
                
                m = newMap;
                var g = m.Values.Where(v => v).Count();
                int f = 56;

            }

            Console.WriteLine(m.Values.Where(v => v).Count());
        }

        public string testcase = @"sesenwnenenewseeswwswswwnenewsewsw
neeenesenwnwwswnenewnwwsewnenwseswesw
seswneswswsenwwnwse
nwnwneseeswswnenewneswwnewseswneseene
swweswneswnenwsewnwneneseenw
eesenwseswswnenwswnwnwsewwnwsene
sewnenenenesenwsewnenwwwse
wenwwweseeeweswwwnwwe
wsweesenenewnwwnwsenewsenwwsesesenwne
neeswseenwwswnwswswnw
nenwswwsewswnenenewsenwsenwnesesenew
enewnwewneswsewnwswenweswnenwsenwsw
sweneswneswneneenwnewenewwneswswnese
swwesenesewenwneswnwwneseswwne
enesenwswwswneneswsenwnewswseenwsese
wnwnesenesenenwwnenwsewesewsesesew
nenewswnwewswnenesenwnesewesw
eneswnwswnwsenenwnwnwwseeswneewsenese
neswnwewnwnwseenwseesewsenwsweewe
wseweeenwnesenwwwswnew";

        public string input = @"neeneneneswneneee
eeeswneseseeseeeseeeeesesee
swswsweswwswswswnw
neseewwswwneswnewnewwswswwswwse
wswsweenweesenweeeeeenweeee
neswwwswwwnewwwwwwwwsewwswsww
neseeeswesweenweeeeeeeeee
neeeneneeneeswneeneneneene
ewwsenwwenwnwswnwswwnewwwsewne
sesesesesesewseseweeeeneweseeww
neeeswnwneswneneneweeneeneswnwnesw
neseswnwnenenewneneesenenenenenenenenenene
eneeeeseseeseesewseseseeeseee
enenewseeenewnweseewnwneseweesw
sesesesesenwseseseseseseseswseseee
nenenenenwneeesweseneeeeeenenenwe
neeenenwseswsenewseswenwewsww
neeenesweswwneeneeeeeeeeenwe
swseneswewwsewsweeeseeswwsesww
nenwwnwnwswwnwwnwnwnwnwnweswswnenww
swswseseswnwswswswseswseeswswswswnwswsesenw
nwnewwswnwesewnwwwsenwwnewewe
newwsewwsenwswwswswswswseswwnwwwsw
swswsweswseswswwswswnwseswswswswswswswsw
nenwnwnwnenwnwnwnenenwnenwneswnesenwenw
nwswnwwnwnwwnwnenwwse
neesweeeesewewneese
nwneweswwwswswwswwswswsewsw
wwwwsenwwnwneswsewsewnenewnwwseswne
eeeeeneneneneweneeeeeweswnene
enenwneneeneswnewnweewseswneswnew
swsesesesesenweswseseseswswseswswsesese
nweeeneweewsw
nwswswneswswswneswsewswswswswsesw
swenwwnenwnwnwswnwsesenenw
swswswnwneswswswseswswswswswswswseswse
sweseseseeseseweenese
wnwnwnwnwnenwnwswnwnwenwsenwenwnwnene
eeenweeeeeeeeeeesweeee
nesenwswnwseswneewnenwenwsenwenwewnw
eeeeeewesenweeseeeeswe
swwwswneswsewwswsw
nwnenwnenwnenwnenesenenwnwnwnwnwnwwnw
newnesewnwnenwneneenwnenenwnenenenenesw
eeeeeeeeeeenweeeseeeesw
swnwnwwnwwwnwwewnwwsewwwwnwnew
nwnwnwenenwswnwnwnwnwwnwnenwswewnwnw
swseenwnwswnwnenesenenwnwneeswneenwwnw
enwwseeswwenwswswesw
enwseseeeeeeenweeeseeseswseee
eseswseseswseneenwwneeswwwse
swswswwesenwswswswswswswswswswsenesesw
neswenwswswswnwnwsweswnweswswsweswsw
newsenenwswesewenesewwseeesenwesew
seswswswswswswneseseswweswseswsewseswnw
wnwwwwnwnwnwwnenwwewnwnwswnwnww
newwwwwwsenwwwewwwnwwwww
seseseeeswseseswseswswwsewseseswswse
eenenwswnenwneswnesenwnenenenwnwnenenewsw
swnwewswwewnwnwswwwnwnwewwwse
nwenewneneneewnene
wwwwwswwswenwwsewwwwwwswsww
enenewswnwneneneneseneneneeneneeneene
wnwswswnewwwswnewwwsewwseswnew
nenenwwsenweswnwswswnwswnwnenwnwne
seeenwesesesewseseeseseeesesesese
eeneeeeeeeneenwenweswsweeene
wneneneswseneneneneneneeneenenwsenwnene
seseseswsenewesesesenwneseseeseseesese
wsesenesenwsesweseswnwsesweseseesenwsese
wwwwnwwnewewwswsenwseseewnwnenwnw
wnenenenenenenenenwnenenwnenenesenenene
neeewnwwneneesweneeweseswnwneswsw
neesewwneenwnwwwwseswwnwwwwswww
esweeeeeeneneenwe
eseeseeeeenwswseeseneeseseseswee
neneenewnweneseswnenenwneneenwwseswne
senwwnesenwswnwneeewswnenwnwwnwnwsene
eeeeseeeeeneewwneeweneeenene
nwnenesenwwwseswseswnwwesesenwwnene
swseneswswswswswsewswnwneseswseneeswsesw
nwnwwnwswnwnwwnwnwenenwswwnwnwnwnwenw
seswswseeesesenwnweeseeeneeenewese
nwsenenesenwwnenenwnwneswnenenenenenene
swsewnwwwseswwwsewneneswneenene
nwenenwnwnenwsenwnenwnwswnwnenenenwnenwnw
swwneneneneneenweeeneenesweenesenesw
swnwnwswnwwwswsenewsewswsewswswseswsww
enenenenesenenenenenenenenenenwswnenewne
newewesesewseseseseeeseseeesesese
nenwwwnwsewswwwwewsewwwwwsew
enwewnwwwwnwwnwnwnwnwnwnwwwnwnwswnw
neweeswesweeswewneseewnw
swswswswsewesewswswswswneseswswswseswse
swneeewseneeeeeswneewwneseenwe
wwwwwwwwwneewwsewwwwweww
eeeesweneenweeeneneeweeenee
wnenwneseeenwseeneneewneseswwnene
wwwnwewnwnwnwnwnwewneenwnwnwswswswnw
enenenenwesesewnwneeeswneneeneenenene
nwnewseneseenwwwseswneswseneeeswnew
swsewwsweseswneseseeseswneseneswswse
swswswwswswnewsesesweswswswswseneswnesww
enwwnwwnwwnewnwswswseeswnenwwnwwnwse
sesenwnenwnwnenwnwnwswnwnenwnwnenenwnwnwsw
seeneswswwswwswswwwwswwwswnenesw
swwwwswneseswwwwswwnwswswswswwswsew
swseeenenwnwswenwneneenwnwnenwnwsewsw
wswswswwwswwwswswswneswswswseswswsw
neswnewnenenwnenewenenwneneeenenenw
eswneneneneneenenwneneeeneenenewe
enenenenenenwneneeneeeeeeenese
seeseewswwseseneesenwneseseswsewswsw
ewwewswwswwswswwewwnwswwsww
swwswswswswswswswswswne
nwnenwnenenenwnwnwswnwne
nwnenwnwswnwwewnwnwswnwsenwwnwnwnwnw
nwnwnenwnwnwnwwnwnwnwswnwswnwnwewnwnw
eseneseeswenwneeneneneneewnenwnenene
swwnwwswwswswwswwswswswsewwwwswne
swsewsenenweseesweee
nwnwnwnwsenwnwnwnenenwnewnwnwnenwnwnwnw
nwsweeeseseeeeseeeeseneeswene
neenwneneswnwnesewewswneswnwnwneneswe
esenenwnwnewseneswnwsewswwnwsenwsewswse
nwwwweneeewwwesesenwneneswswswnw
nwnwsenwnewseswnwesenewnenenwnenenenwe
wnwwnwnenwnwsenwnewwnwwsewwnwwwwe
wwwewwswwswwwswwwwswsw
swswwswswseswswswswseswswswswnesw
wwwwwwwwwwswwewwnwwwww
nwnenwnwnwnwnwsenenwnwnwnwnwnw
swnwswswswswwseeeswswswswswswsewnwnwsw
nenwnenwnenewnwnenwnwnenwnwseenenwnenwne
seewseeseeeeseseeeweneseseseese
seenesesesesesesesewseseseseesesesese
nenenenenwneneneenweneneneesenenenesene
swswneneeseswwswnwseswswwswswseswsesw
nwswsenwneenwnwnwnwsenwnwwsenwenewnwsw
nweseseseswswswswswswswswswsw
seseswseseseswsenwseseseseesesesesesese
wwwwwwsenwwnewewnwwsewswnesww
nwseswswnwseswswsewseseeseswswesesesesw
seswseseenwswseseseenwswseswseesewswse
nwwnwnwswnwwnwnwnwnwesenwnwnwwwwnww
neneswseneneneswwnenweneeneneenesenww
swswswswneseswswseswswswwswswsesweswswse
swneswseswswswswswswswswswseswswseseswsene
swswneneswswwneswwwswswswwswnweswsene
nenwnwnwwnwnwnwnwnwnwnwnwnwenwnwnwswnwnw
wwneswwwwwwwwewwwnwwwsewww
neneeswnwneneeneeee
swesweswswnesweswsesewwnenwnwnewnwnee
nwwwwewwwwwwwnwwseswwwswwe
sweenwseeseneweseseeewnwseeseenenw
eeeeeenweseeneeeeeeeenesw
nwnwnwswnwnwnwswnwnwnwnweeenwnwswnenw
eneeneeeeweeeeeneeeeneewsee
swnenwnweneneenwnwnwnwswnwnenenenwnwnwnw
nenwnenwnwnenwnenesenenwnwnwnenw
neeswnweswswseewwnwwweswwwwwne
nwseeeeeeweseeeeseeeeeeee
sweseneneseeseeseeneeeeeewsweew
wnwwnewswwwswwwwewwwwnwww
wswnwsweswwneseswnwswswwseswsweswnwwsw
nweswneeweeeeswsenwew
neeswneneenenweeneneneeneseenesenwe
nwnwnwnwnwnwnwnwnwnwnenenwnwnwnwsenwnwse
seswseseswseseswseseseseswsesenw
nwnenwewnesenwnwnwnwnewnenwnenwne
swswswswesweswswswwswswswswswswwswsw
nwnweeeeeeeeeseeeeeeeese
wswnwnwswswswwwwswswswswswwwseswswse
seneswwseswsesewsenwsenenesenwseseese
neneneswneswenenweeneenenenenwnwswnene
newwwnwwwwnwsewwwwseswwwwse
swsenwenwnwnwnwnewnwswenwwesw
newwnwnwnewsewwswwwwnwnwnwswww
eseswsenenesesenwwseswseseseeseesese
nwwenwenwsenwnewnenenwnwwnweneswnwne
neswneneseswseeseseswswsenesenwswswsww
neneeeswseneswnwnwwenenenwseswwwe
nwswseseseeeseseseseesesesesese
wswwnwswswnenwneswnweswseenwewwwse
swseseswseneswswseswswseseswswnwswseswswsw
sesesenwseswseseseseseeesesesesesesese
nenenenenenenewwneeeneneseneeneneene
wnwswwewswnwnwsenenwesesweeswsene
enenenwneneneeneeeneeseswneenenenene
seenwseseeneeswwneseeeseswwesenww
seseswnwwsewnewswnwseswneswswswesweenw
nenenenenwnwnenenwwnwenwnenw
nwwwwnwneeeeneneneseswsenewesenw
swswswneneseswwwwswswswswswnwswswswsw
nesesenwswswseswnenwsewswseseseseswnese
neeeenenweswenweneneeneeneeeeese
seeweneseeneseseseswseewsenenwe
seseseseseseseseseseseseseseswsenwsw
wswswswswsweswwwwseweswwwswswne
nwseeswneswneswwnenwseswenewseswwsw
neeweenweeeeneeeeeesweeeee
swwswwswwneweswwswswwwswsewwsw
sesweswwswenwweswswesenwnwnwnweswse
nwneenenwnewenesw
wnwseewwenwwwwesewwwnwewwnw
eeeneesenenenweswene
seenwseseseeseseewsweesesesewsese
wswsweswswseseseseseseseseswswsesesenwse
wweeeeeneeseeeeeeeeesese
swseswseseseeswsenenwseswseseseseseswsw
wwwewwwwwnwswwwnwnwnwwwewnw
wwnwnenwseneeswswswewewswswswwenw
neswswswswswseseswseseseseswseesenwswsw
neeswnewnwwswsenwnwnenwnwsenesewene
nenwseeswwswseswsesesweseswswswswseswsw
nwwwwseneneswseseneeseswswnwnwseene
seesesesesenwseweseeseseeseseswseese
ewwwswswwsewnwwwwswnewneeswsw
eeneneneneneneeneenenewnenenenesewne
enweeswnwsweseneeneenwsenewnwswswne
sesenwseewsesenweseeeseseeeseeenee
nwnwnwnenwnwnwswnwnwnwnenwnwenwnenwswnwnwnw
seswnwsenwnenwnwnenwnenwnwnenw
nenwnwnwsenwnwnwnwnwnwnwnesenwswnwnwnwnwne
swnwnenwnenenwnwnwnwnenwweenwwenwnwnwnw
senwnwnwwnwwwwnwwnwnwnwswnenwnwnwnewnw
neswnenwswsesewnwnewsewwnewnesenewnwnw
wwwsenwnewwwwewwnwwwwwsww
enwneeneneswswnesw
enweesesewsenesesw
eeswewneesenenweneneneneneeseee
nwnwseneswnwnwwewwwwsenwwwnwww
swwneswneswwwswsweeswswswwswswseswnw
ewwwwwsewswwwwwwenwwwneww
swneswseeswswswwswnwsewwswswswswwswwsw
sweswwswseneseeewswwnenwnwneewwsw
swwswswseswswswwswswswswswswswwswswne
nwwwswwwwwwswwweweswneswwew
neneneswsenenenwnenenwneswnweweenwsww
senwswnewwseseeseenewseseneeeswene
nenwsewwsenewswseenesewsenenewnwe
swswswswwwwwewswwnewwswwwwww
swsweswsenwnweenenwe
wnwsesesesewseswnesenesenwswsesesesesesese
eeewseeeseeweeeseeewwenee
eeeeeneeeeeeeweseeewwe
neneneneenenwneneneneneneneneneneneswne
seeseeseesesesenweseeeswneenwnwee
seeeseenwswneeeewswewneseeew
nwseenwnwnwnwnwswnwnewwseenwnwnwsenw
esweeeweweneeseeneseee
ewswnwswswwnewswwsweseswweswswww
sweseeneswwwwnwnenwsenwwsweseswe
eweeseseeswnwneneeeneew
swnweseeeeeneweeeeeeweene
wwnwwweswwnenwwnwnwswwwewwsw
neneeeweenewneneeeeneeeneswe
swwwesewnwsenenwnewnwneseenwwswnew
senwnwnenwnwnewnwneneswwneeneneenewse
nwwwnwwwwwnwwwwnwsewnwwwsew
wwwswwswwwswwwwseneneeswwwww
neswswseswswnwseswseseswswwseswsesesesese
nwsewnwnwwnewnwnwnenwneenwnwseneenw
seseseseseseseesenewsesesesenesewsese
newwnwnwnwwnwwwnwsenwnwnwwwsenww
swswenwnewswswswneweweswswswswnwsesese
seeseswseseseseesesesesesewseseswnwse
nenewneneneswnenwsenenenenewneenenenee
sewseneseswneseneseeewswnwswsewswwsw
eeswwswswswswswswswswswsenwswswnwwswsw
seneenwswseseeeneeeeeswswsenewe
nenenwnwnenwenenenwnewnwwsenenenwnwne
nenwenwswenwnenwnwsenwwnwenwnwswnwnw
wwwsenwwswnwwwewenewwwwwnwnw
nwnwnwnesenwnwnwsenwnwnwswnwnwnwnwnwnwnw
swswswswseswsweswswnwswwswseswneswswswwsw
eswnenwneenwewnwnwnww
seseseseeseneseseseseseseweeseseseswnw
enwwnwnwswnwnwnwnwwwnwnwnwwnw
swsewseneswneewwwwnwnwnwnwwseswsesww
nenesenwnenenenenenenenenenewneneswnee
nwweswwsweswswswneswswnwswswswswww
neeneeneneneeneenenenenenenewsenene
nwswswswsweswwswswswwswewwwswswsw
swwswwwwwswwseswswswnwweneswswsw
wswnwneeneswnwwswwnwwsenenewwnwww
nenenenenwwenwnwnenwenenww
seseneseseswwneseeseewseseesesenwse
nwenwsenwnewneswnwnenwnwnwneenwnwnwnenw
nwnwnenwnwnwnwnweswnenwsenenwnwnwnenwnwwne
nwnenwenwswnwenwwswnenwnenwnwnwnwewnee
wwnwenwnwwnwwwnenwnwwnwnwnwesww
neseeneeeneeeeewneneneneeenee
swseseswnwneeseseneswswwswswnwswse
swnwswseswswwswswswneswsw
swwweeeeswnwneneeewnweeeeee
enenwnenwsenwswnwnwnenenwnewnesenwnwsenwnw
swewswwneneseeeenwneenenwnenwseee
seseseseseenwseneseseeseswseeseswnwse
seneeeseseeeseswnwswsesesenwwwseenw
wwnewwwwwwwsenewwwwwwswwnww
nwswwwswswwnwsweswswsweswswsesweswsw
swswnwnwnwnwwenwnwnwenenwnenw
seeseseseseweseseeeseseesee
wnwnwnwsewnwnwnwnw
nwnenenwnwneswnwnwnwnwnwnwnwneenwnwwnw
sweeseneweseneswenwsesenweswsenwnee
wswnwnweseseewenenenwenenesweene
nwnesenwnwseesewneswwnesweswnwnwsenww
sewneswwwnwewnenwnwnwwwswnwwnwswe
eeesweseneeweenweeswenweneewe
neneneeneeeeneneeesweeenwenene
eeneneeeneeeenwneeswweneenenee
sesweeneeseeeweeeenweeeese
swnwswneewwwnwwsewwnwnwwnwnwwenwnw
eeeeesweseeeseswenwnwenwnwee
sewwnewwswwwwswnesewswsw
nesewseewseswsesewwswweseseneswswe
newneenwsewnenenenenenwne
sewsenwseeseesewneswwwnwsenweswnene
swswswwwwwswwwswneww
wnewwwwwwwwwwwwwwwswsw
swwwnewwwwswsenwnwwwnenwseenww
neeenenwweneeneeneneneneneeneneswse
nwsenwnwnwnwnwswwnenenwsewnwswnwenwse
nwesenwnewwnwwwnwwwwnwwswnwnww
neswwsenwswnwwwswswseswswwsw
neneeneswneneneenewnewseenenenenene
seswseswsesesenesesesesesese
wwwnwwwwweswewswnw
seneseswsesewseseneesewwseswwswsenese
enenwnwnwwnwswnwnwnwswnwenwnwswenwnw
neswwsenwswsweneswswnwswseswnesenwnesw
senwwnweswseswneswneewneseesesesesene
nwenwwnesenwnwwswenwnenwswnenwnenwse
weneeseeneeswweswnweswenwewswnw
eswnwewwnwnwswwswwswene
swwnwneseseseneneseswewswwsenewseee
seswwnwwwswseeswwswnwwsewwenene
neeneneneneneenenenenewsenenenwswnene
eesesweeeeeeeneenweeweseww
seswswswnwswswsweswswnwswswswseswswswsesw
nenwnwnwnenenwnwnwnwwnwsenesenwnenwnew
neneswneneneenesenwnenenwnenwwnewnesene
wnwnwewnwwswsenewenenwnwswwwwwwnw
weneswnenwnenwnenenenenwnenesewnwnene
eneneewswneenenwswnenweeeeneesee
neswseseswseswwseseseseswnwnwnwswnwsesw
nenenenenenwenenewnwnwwsenwnenenenene
weseswnewnenwwenwnwnwewnenenwsenw
swenwnewewwwnwneswewwsewnwsewnw
seseseseneswseseswseswseseseseswnesewsesese
nwnwnwnenwnwnwnwnenwnwenwnwnwnwnwnwnwsww
nwesweeeneeeeseeeeeneeeeee
esweseswnenwsenwnw
swneswwswswswewswwnwnewswsenenenwsw
enenwnwswnwnwnwsenenwnwnenenwnwnenwnwsenw
neswneswswswsenwseseneswseseneswseswswse
ewneneenwnenwneneswnwnw
swsenwsenesweswwnwsenesewswswwseswswsesw
swwswwswwwswwswswwswnwswswswe
nwwnewwewwwwswneswwswswseswswsw
seeseswwnesesenwsenwswweseswenwnese
nwnenwneneswswwnenesenenwnenenwnwnenenene
nenwnenwnwswnwnenwnewneneneneneneneenwne
eeeenenenenwneneeeeeeneewsese
neseswsesesesewsenewsesenwseneswnesesw
eswnwswsweeswnwnwnwwswwwswwesesesw
wnwwsenwwwenwswswswsewwenewnwwnw
seweeeeeeeneeeeseenwswnenwee
nwsenwwwwwwwwwwwwnwwwneww
swneswswswswwswsweswwwswnenwwswseswsw
swneeeeeeesweenwneneeeeeee
neewsewswseswswsenwswswneswwswenesw
wnwnwsewwswnwwwwnwnwnwnenw
neseseeseswsesesewswsenwswseseswseswswnw
nwenenwnwnwnwnwnwnwwswnwnwnwnwnwsenwe
neneeewnewnweseenenwswwnesewsee
sesewseswneswswseseswnwswswneswneswswe
seseseswseswsesesesesesesesenesesewsesenwse
enwwwswswwwnwsesewwewwwnwew
nwsenwnweseswnwnenwnwnwnwnwnwwwswnwnw
nwseseeneseesweseseseseseseseeswnwsese
seswswseswneseswswneswswswseswswswswswswnw
swswsenwseswswseswswswseseneseseseswneswsw
seseeseswswswswswseswnwswswnwsweswsesw
wneseswseseneseesenenwwnesewseswswese
neneswnenwnenenenenwneesenwnenenenwnwnene
sweneseweseeeeeseeeeeenweeee
enwnwnwnwnwnewenwsenenenwnenenwnwswne
weeeeneeeseseeeeseseesewewee
wsenwnwsewwwwwwwnwwnwnewnwww
nwnwewnwnewnwsewnwwnwnwnwnwwwwwse
swswswwwwswwswswsewnewwwswwneww
nenwswewwswneswwswswwweswswwww
neneneswenenenwneneweewnwnenenenene
swswseneseseseseswseswsese
nwnesenwnenenewneseswwwnwenenwseene
wsesewseseseseseseesesesesesenesesese
seseweswsesesesesesesese
nwnwnwnenwsenwnwnwneswnenwnenwenwnenwnw
seseswewseneseseseseseseswswsesewnese
seswseswsesenesesesesesenwswseseseswsese
sweenwseeeeeeeeenweeeeeeswe
eenwwnewswsesewewswswseneswnewww
wwwwwwwwwnwwsewww
wnwnenwswenwnwnwnwse
swneseneneswneneesewwnenene
wwswewwwwwwwwnwwnwwwswwswwse
sesesewseeseswsewseswnesesesesesesene
swwwwwwwwwswwwwnewwwsenesw
swswseswswnwswswswseseeswsw
newwswsenwnewwsewseseswenwneeswwnw
nwsweswswswswswswnwswswswseswswswswsesw
nwswneseswseswsenewenewwneseewsenw
sewseneseneseseseseesewseseneswsesesese
wnwnwenwnwnwnwnwnwnwnwsenwnwneswnwnwne
sewneewwsesenwnwnewwswwwwneswwsw
wwwnwsewwwwswwwwwnwwwwwe
ewneenwseneneewswneswneenenwenee
swwswswswswswswneswswseswswweswswswswswsw
nwswnwswnenenwswneneneneeneene
esenenenwneneneswenenewneneneenenenenene
swswsweseewweswwsesw
enwewwnwnwsenwneseswwesewnewenew
eeeseseseeneesweeeeeee
ewenwwwswwseswnwswnwwswsweswwww
wnwweeneenewnenenwnewswneeesew
nenwnenwnenenwswnenwnewnwnenwenwnwnene
neneneseneeeneneesewneneeew
neneneneneneneenenwneneneneswneenesenene
nenwnenenwnwnwenenwnwneneneenewswnenenw
swwwswwwwewswswswwwswnwseneswswww
neenenewneneseneneesenewenenenenwnwnese
wnwwweswswswwswweswswwswwswwwwnw
wswwwewwswwswwwwwwnwwwsw
senwesewenwseseswesesesenwswnwsesee
nwnwnwnwnwneneswnwsenenwnenwsenenwnwnw
seewwwwwnwnwwwwnwneswwwnwswnww
seeweseeeseeeeseneeswseeseene
enesweeweeeneesweneseeeeneee
senwseweswneeesweeneseweeesenesew
swswseswseswswsweneswswswwenwwneswsw
swswswwewnwswswswswewwswswswswswswsw
swswswseswsesewseswseenwseswseswnwnesese
ewswswswswswneswswnwwenwsesenwswwsee
swnenwweesenwswnewneneneswnwnwnwswnenw
nwnwnwnwnenwswnenwnenwenwnwwnwnenenwnwne
neneseenewnenenenewnenenenesenenenenenee
nwnwnwswnenwnwenwsenenwnwnenwnwnenenwnwnene
nenenenenewnenewsenenenenesenenenenene
swswswswseseesesesenwswswsesenwseseseese
neneneweeeenesesewneweneeeneene
wwnwewswsewwnewwnewwwww
seseeeeseeeeeesewseee
senesesesweseswenwnesesweseneeseswe
wweeswswnwswwsesesewesenwseewee
nwwnwwnwnwnwnwwwnwnwswenwwnwnw
wwswnewwwwwwwwwwsewwwww
neneeneneneneneneeneenenesenenenewne
neweseeeeseeeeeeeswseeseesee
nweneneswnwnwnwnenesenesewnwnwneenwnwnw
neneseswnenenwnwswwnwnenwnewseneseneneenw
nenenewesewseweeeswswneswneseee
swswseseeseseeeseesesesenwsesesesenwsese
seneeneenweeneneenesweeewneee
wwwewsenewwswneeneeswseswswenw
nwnwwnewsenewswnesenwwwnwenwwsenwnw
seeenwneewnweswnweewseewseese
sewnwswwwwnewwnewnwwwsewwww
swsenwnwewnwnwnwnwnwnwwnwnw
enwesweeseeneswneeseewsewwnee
wnwweneswswwsenwwwnwwwwnwnwww
wwwswwwwwwnewswwwweswwww
swswnewswswsweswswwwswseswswwwsw
wwwnwwewnwwwwnwwwwnwwwnwsew
nwnwnwnwnwsenwwnwsewnwnwnwnwnwnenwnwnw
nesenweswnenenesenenenwneneeeneenwne
sweeeseeeeesenweseeseseeese
eseswwswseswseswneseseseseseswswseswwswsw
nwenwnwsenwnwnenwnwnwnwnwnwsenwnwnwwne
wewwwwwnewwwwewwnwwswww
wnwwwswswneeswswswswswseseseesenwesw
seweeeenweeeeesweeeeee
nenenenenwsewnenenwneneswnenenenenenenene
neesewneswneeeneneneneeenwwwneene
swseswneswseswwesesweswswswnwseswnwswswe
newnwwwseswswwswwswnwswwwsewswwne
swswswwswswswswswsenwseswnenewswwswsw
neeneenenewneeweeeswneseeeeee
newsewnenwnewsenesewnwee
nwnwswswseseneswswnweseswsenwneseweswsw
seswswwwwwswwneswswwenewswne
eneeenwwnwwwwwswnwnwswnwnwwww
nwnwnwnwnwnwnwwewnwsww
seeswneseseseeseesesesewenwseenwwse
nwnwwswnwwwwewnwnwwwnwnwwewnwew
eeseseseeeseneseeeseseeneseseswwsese
swwswswweswwwnwswneswwswswswwww
wnwswwwwwnwnwwwsenenwewswwwnenw
sewswseseswnwnwsweenweswwseswswswnenwne
wwnwwwnwnwwwwwnenwwnewswnwwnwwse
seweswwneeswsenwswnwwswswswnwseswwsw
nwnenenwnwnwneswnenenenenwenwnenwnenwneswne
sewsenwnenwnwwwnenwnewwsenwwnwwnwse
seseeseseenweneseweseswswswnesesenw
swwneswwwwswwnewwswwseswswwsww
seesweswnwseseseswnwnwswswnwse
eesesweseeeseeeeeeenwsweene
swseswswswseswswswswswswswwswswenwswsesw
swwswswsweswwwnwswswswnwswwsewswsw
nwnwwwnwwnwnwwnwwneenwwwwnwsesee
weeenwseseseseeseenesesee
nwnwwseenwwwwnwwnwwnwnenwsenwnww
eeeeseseeeeswseeseseswneseeseeenw
eeeeeneesweeeesweeenenweeee
eweeseneeseesesenesweeseewsewne
neneneswswenenwwnenewsweneswenwswsenw
wwswnwsewneseswswneesenewswwwsenwsw
seswswsweswnweswesweswswwnwnwsesese
weneeeneeeeewseeeeeeeneee
nwwnewwswwswswswwwswswwewswwwe
seseesewseneeseesesweswsenwwsenwsese
wenwseeswwnwewwneswnwenwwnwnwse
wwwewswwwwwwwewnwwwwwnww
seseswsesweweeesenweeseeeeseesenw
swseneswneseswwswswswswseneseswswswswsesww
esenwseseeeseseseesesesesenwwnwseene
neeneneneeneeenenenwwswe
wnewwswswswwwswswswswsewswwswwsw
eswnwesenesweeeneesweeneseeesw
nenwneneneeswneneneswnwnenene
swswswswswswswneseswswenwwnweswswswsw
eeeeneeeneeewneneeeeeeenwesw
neneeesweseneneenwseenwnee
nwnenenenwswewnwnwnwnwnwnweswseswnenw
wneseseseseseseswseneswseseswsesesesese
wswsweseseswswneswwswneswneswswnwswsw
swnwnweneneswsewnenwnw
nwnwnwnwnewnwnenwnenwnwnwnwnwnesenenesene
nenenenenenwnenenwneenwswnenwsenenenenw
swnwswnweesenwswswswsenwswseseeswswsesw
ewswnwseswsenweenwsenesesewsee
nwnewseewsewnwnwnesewwnwsesenwwswnw
nwnwnenwnenwneneneenwwnenenenwswnwenenw
nwwwswwwwwwnwwwswwenwnwwwe
wnwsenesenwswsewswneswswnwsewswwwwsw";
    }
}
