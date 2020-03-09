import numpy as np
import matplotlib.pyplot as plt

x1 = np.linspace(-10, -0.1, 30)
y1 = 1 / x1
x2 = np.linspace(0.1, 10, 30)
y2 = 1 / x2
plt.xlim(-10, 10)
plt.plot(x1, y1)
plt.plot(x2, y2)
plt.show()
