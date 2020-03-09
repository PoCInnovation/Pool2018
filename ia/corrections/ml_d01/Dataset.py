import re
import math

class Exemple:
    def __init__(self):
        self.inputs = []
        self.outputs = []

class Dataset:
    def __init__(self, filename):
        try:
            file = open(filename, "r")
        except:
            raise ValueError("Cannot open dataset")
        else:
            line = file.readline()
            nbrs = [int(x) for x in line.split()] # Parse read line in number list
            self.nb_exemple = int(nbrs[0]) # Get nb exemples, inputs and outputs
            self.nb_input = int(nbrs[1])
            self.nb_output = int(nbrs[2])
            self.exemples = []

            for i in range(0, self.nb_exemple): # Read each exemples
                inputline = file.readline()
                outputline = file.readline()
                self.loadData(inputline, outputline)
            file.close()

    # Create an new exemples with 2 readed lines
    # (1 for inputs and 1 for expected outputs)
    def loadData(self, inputline, outputline):
        ex = Exemple()
        inputs = [float(x) for x in inputline.split()]
        outputs = [float(x) for x in outputline.split()]
        ex.inputs.extend(inputs)
        ex.outputs.extend(outputs)
        self.exemples.append(ex)

    def computeMean(self, index):
        sum = 0
        for i in range(0, len(self.exemples)):
            sum += self.exemples[i].inputs[index]
        return sum / len(self.exemples)

    def computeStandardDev(self, index, mean):
        sum = 0
        for i in range(0, len(self.exemples)):
            sum += math.pow(self.exemples[i].inputs[index] - mean, 2)
        return math.sqrt(sum / len(self.exemples))

    def normalize(self):
        for i in range(0, len(self.exemples[0].inputs)):
            mean = self.computeMean(i)
            s = self.computeStandardDev(i, mean)
            for j in range(0, len(self.exemples)):
                self.exemples[j].inputs[i] = (self.exemples[j].inputs[i] - mean) / s
