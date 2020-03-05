import time
from win10toast import ToastNotifier
from playsound import playsound

toaster = ToastNotifier()

maps = ["Academy",
        "Ancient City",
        "Arena",
        "Armoury",
        "Bone Crypt",
        "Cage",
        "Cells",
        "Colosseum",
        "Conservatory",
        "Coral Ruins",
        "Core",
        "Courtyard",
        "Cursed Crypt",
        "Desert",
        "Dungeon",
        "Factory",
        "Flooded Mine",
        "Gardens",
        "Ivory Temple",
        "Lava Chamber",
        "Maze",
        "Mineral Pools",
        "Museum",
        "Necropolis",
        "Orchard",
        "Overgrown Ruin",
        "Overgrown Shrine",
        "Palace",
        "Pen",
        "Pier",
        "Pit",
        "Plaza",
        "Precinct",
        "Residence",
        "Scriptorium",
        "Shrine",
        "Sunken City",
        "Vaal Pyramid",
        "Villa",
        "Wasteland"] 

with open('C:\\games\\poe\\logs\\Client.txt', 'r') as f:
        f.seek(0, 2)
        while True:
            line = f.readline()
            if not line:
                time.sleep(2)
                continue
            print(line)
            if not "You have entered" in line:
                continue
            for map in maps:
                if map in line:
                    playsound("Media\\Cancer.wav")
                    toaster.show_toast("DO NOT RUN MAP", map)
