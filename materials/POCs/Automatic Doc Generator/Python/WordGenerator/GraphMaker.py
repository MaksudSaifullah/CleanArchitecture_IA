import matplotlib.pyplot as plt; plt.rcdefaults()
import numpy as np
import matplotlib.pyplot as plt

def graphMaker():
    objects = ('Rare', 'Unlikely', 'Moderate', 'Likely', 'Almost Certain')
    y_pos = np.arange(len(objects))
    performance = ['Insignificant', 'Minor', 'Moderate', 'Major', 'Catastrophic']
    plt.bar(y_pos, performance, align='center', alpha=0.5)
    plt.xticks(y_pos, objects)
    plt.ylabel('Impact >', fontsize=22)
    plt.xlabel('\nLikelihood >', fontsize=22)
    plt.tight_layout()
    plt.savefig("graph.png")