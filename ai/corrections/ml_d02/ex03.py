import matplotlib.pyplot as plt
from Dataset import *


if __name__ == "__main__":

    dataset = Dataset("ex03.ds")
    
    x_red = []
    y_red = []
    x_blue = []
    y_blue = []
    x_green = [0.4]
    y_green = [0.4]
    
    for ex in dataset.exemples:
        if ex.outputs[0] == 0:
            x_red.append(ex.inputs[0])
            y_red.append(ex.inputs[1])
        else:
            x_blue.append(ex.inputs[0])
            y_blue.append(ex.inputs[1])
            
    
    plt.scatter(x_red, y_red, c='r')
    plt.scatter(x_blue, y_blue, c='b')
    plt.scatter(x_green, y_green, c='g')
    plt.show()


# Pour K = 1, la catégorie assignée serait 1 (le voisin le plus proche est bleu)
# Pour K = 3, la catégorie assignée serait 0 (2 des 3 voisins les plus proches sont rouges)
