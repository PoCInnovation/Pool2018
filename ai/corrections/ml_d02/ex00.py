import matplotlib.pyplot as plt
from Dataset import *


if __name__ == "__main__":

    dataset = Dataset("ex00.ds")
    
    x_red = []
    y_red = []
    x_blue = []
    y_blue = []
       
    for ex in dataset.exemples:
        if ex.outputs[0] == 0:
            x_red.append(ex.inputs[0])
            y_red.append(ex.inputs[1])
        else:
            x_blue.append(ex.inputs[0])
            y_blue.append(ex.inputs[1])
            
    plt.scatter(x_red, y_red, c='r')
    plt.scatter(x_blue, y_blue, c='b')
    plt.show()
