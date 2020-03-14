import time
from playsound import playsound

maps = [#"Academy", #4, 7, 11, 12, 14
        #"Ancient City", #3, 6, 10, 12, 14
        #"Arena", #3, 6, 10, 12, 14
        #"Armoury", #2, 5, 9, 11, 14
        "Bone Crypt", #4, 7, 11, 12, 15
        #"Cage", #3, 7, 10, 12, 14
        "Cells", #0, 0, 10, 13, 15
        "Colosseum", #0, 0, 12, 14, 16
        #"Conservatory", #4, 7, 10, 12, 14
        "Coral Ruins", #0, 0, 0, 0, 15
        "Core", #0, 0, 11, 13, 15
        "Courtyard", #4, 8, 11, 13, 15
        #"Cursed Crypt", #2, 6, 9, 11, 14
        #"Desert", #2, 6, 9, 11, 14
        #"Dungeon", #0, 0, 0, 11, 14
        #"Factory", #0, 0, 9, 11, 14
        #"Flooded Mine", #0, 0, 9, 12, 14
        "Gardens", #0, 9, 12, 13, 16
        #"Ivory Temple", #0, 0, 0, 0, 14
        "Lava Chamber", #4, 7, 11, 14, 16
        #"Maze", #0, 0, 9, 11, 14
        #"Mineral Pools", #0, 0, 0, 0, 14
        #"Museum", #3, 6, 10, 12, 14
        #"Necropolis", #0, 0, 0, 0, 15
        #"Orchard", #2, 6, 9, 11, 14
        "Overgrown Ruin", #3, 7, 10, 12, 15
        "Overgrown Shrine", #0, 0, 0, 13, 16
        "Palace", #0, 0, 0, 0, 15
        #"Pen", #3, 6, 9, 12, 14
        #"Pier", #1, 4, 8, 10, 14
        #"Pit", #4, 7, 10, 12, 14
        "Plaza", #4, 8, 12, 14, 16
        "Precinct", #0, 7, 12, 14, 15
        #"Residence", #0, 0, 10, 12, 14
        #"Scriptorium", #0, 5, 9, 11, 14
        "Shrine", #0, 0, 0, 14, 16
        "Sunken City", #0, 0, 0, 14, 16
        #"Vaal Pyramid", #3, 7, 10, 12, 14
        #"Villa", #2, 5, 9, 11, 14
        #"Wasteland", #3, 6, 9, 11, 14
        ] 
        
a = ["#", "@", "%", "&"]

with open('C:\\games\\poe\\logs\\Client.txt', 'r', encoding="utf-8") as file:
    file.seek(0, 2)
    while True:
        where = file.tell()
        line = file.readline()
        if not line:
            time.sleep(2)
            file.seek(where)
        else:
            print(line)
            if "You have entered" in line and not any(x in line for x in a):
                for map in maps:
                    if map in line:
                        playsound("Media\\Cancer.wav")
                        time.sleep(10)
