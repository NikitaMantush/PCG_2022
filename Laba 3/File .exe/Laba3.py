import cv2 as cv
import numpy as np
from tkinter import *
from PIL import ImageTk, Image
from copy import deepcopy


class MainSolution():
    def __init__(self):
        self.image = cv.imread("Adams_The_Tetons_and_the_Snake_River.jpg")
        self.imgray = None
        self.trsh1 = None
        self.trsh2 = None

    def original(self):
        img = Image.fromarray(self.image)
        img = img.resize((300, 300))
        return ImageTk.PhotoImage(img)

    def vincent(self):
        img = cv.ximgproc.thinning(self.trsh2)
        img = Image.fromarray(img)
        img = img.resize((300, 300))
        return ImageTk.PhotoImage(img)

    def filt(self):
        self.imgray = cv.cvtColor(cv.pyrMeanShiftFiltering(
            self.image, 15, 50), cv.COLOR_BGR2GRAY)
        img = Image.fromarray(self.imgray)
        img = img.resize((300, 300))
        return ImageTk.PhotoImage(img)

    def local_threshold(self):
        ret, thresh1 = cv.threshold(self.imgray, 0, 255, cv.THRESH_BINARY_INV | cv.THRESH_OTSU)
        self.trsh1 = deepcopy(thresh1)
        img = Image.fromarray(thresh1)
        img = img.resize((300, 300))
        return ImageTk.PhotoImage(img)

    def adaptive_threshold(self):
        thresh2 = cv.adaptiveThreshold(self.imgray, 255, cv.ADAPTIVE_THRESH_GAUSSIAN_C, cv.THRESH_BINARY, 11, 2)
        self.trsh2 = deepcopy(thresh2)
        img = Image.fromarray(thresh2)
        img = img.resize((300, 300))
        return ImageTk.PhotoImage(img)

    def niblack(self):
        img = cv.ximgproc.niBlackThreshold(self.imgray, 255, cv.THRESH_BINARY, 11, 0.2)
        img = Image.fromarray(img)
        img = img.resize((300, 300))
        return ImageTk.PhotoImage(img)

    def segmentation(self):
        img = cv.bitwise_and(self.image, self.image, mask=self.trsh2)
        img = Image.fromarray(img)
        img = img.resize((300, 300))
        return ImageTk.PhotoImage(img)


    def bilateral_filter(self):
        img = cv.bilateralFilter(self.image, 9, 75, 75)
        img = Image.fromarray(img)
        img = img.resize((300, 300))
        return ImageTk.PhotoImage(img)

    def edge_detection(self):
        img = cv.Canny(self.image, 100, 200)
        img = Image.fromarray(img)
        img = img.resize((300, 300))
        return ImageTk.PhotoImage(img)

    def canny(self):
        img = cv.Canny(self.trsh2, 100, 200)
        img = Image.fromarray(img)
        img = img.resize((300, 300))
        return ImageTk.PhotoImage(img)

    def euclidean_distance(self):
        img = cv.distanceTransform(self.trsh1, cv.DIST_L2, 3)
        img = Image.fromarray(img)
        img = img.resize((300, 300))
        return ImageTk.PhotoImage(img)

    def shi_tomasi(self):
        img = cv.goodFeaturesToTrack(self.trsh2, 25, 0.01, 10)
        img = np.int0(img)
        for i in img:
            x, y = i.ravel()
            cv.circle(self.trsh2, (x, y), 3, 255, -1)
        img = Image.fromarray(self.trsh2)
        img = img.resize((300, 300))
        return ImageTk.PhotoImage(img)


class MainApp():
    def __init__(self, master):
        self.master = master
        self.master.title("Image Processing")
        self.master.geometry("715x740")
        self.master.resizable(False, False)
        self.master.configure(background="darkgrey")

        self.solution = MainSolution()

        self.frame = Frame(self.master, bg="darkgrey")
        self.frame.pack()

        self.label = Label(self.frame, text="Image Processing", font=("Bahnschrift Condensed", 22), bg="darkgrey")
        self.label.grid(row=0, column=0, columnspan=2, padx=273, pady=20)

        self.button1 = Button(self.frame, text="Original Image", font=("Bahnschrift Condensed", 14), bg="snow", width=15, command=self.original_image)
        self.button1.grid(row=4, column=0,columnspan=3, pady=5)

        self.button2 = Button(self.frame, text="Mean Shift Filter", font=("Bahnschrift Condensed", 14), bg="snow",width=15, command=self.filt)
        self.button2.grid(row=3, column=0,columnspan=3, pady=5)

        self.button3 = Button(self.frame, text="Local Threshold", font=("Bahnschrift Condensed", 14), bg="snow",width=15, command=self.local_threshold)
        self.button3.grid(row=2, column=0, pady=5)

        self.button4 = Button(self.frame, text="Adaptive Threshold", font=("Bahnschrift Condensed", 14), bg="snow",width=15, command=self.adaptive_threshold)
        self.button4.grid(row=2, column=1, pady=5)

        self.button5 = Button(self.frame, text="Segmentation", font=("Bahnschrift Condensed", 14), bg="snow", width=15, command=self.segmentation)
        self.button5.grid(row=3, column=0, pady=5)

        self.button6 = Button(self.frame, text="Bilateral Filter", font=("Bahnschrift Condensed", 14), bg="snow",width=15, command=self.bilateral_filter)
        self.button6.grid(row=3, column=1, pady=5)

        self.button7 = Button(self.frame, text="Edge Detection", font=("Bahnschrift Condensed", 14), bg="snow",width=15, command=self.edge_detection)
        self.button7.grid(row=4, column=0, pady=5)

        self.button8 = Button(self.frame, text="Euclidean Distance", font=("Bahnschrift Condensed", 14), bg="snow",width=15, command=self.euclidean_distance)
        self.button8.grid(row=4, column=1, pady=5)

        self.button9 = Button(self.frame, text="Niblack", font=("Bahnschrift Condensed", 14), bg="snow",width=15, command=self.niblack)
        self.button9.grid(row=5, column=0, pady=5)

        self.button10 = Button(self.frame, text="Close", font=("Bahnschrift Condensed", 14), bg="rosybrown",width=20,  command=self.exit)
        self.button10.grid(row=9, column=0,columnspan=3, pady=0)

        self.label1 = Label(self.frame, text="Original Image", font=("Bahnschrift Condensed", 14), bg="darkgrey")
        self.label1.grid(row=7, column=0, pady=5)

        self.label2 = Label(self.frame, text="Processed Image", font=("Bahnschrift Condensed", 14), bg="darkgrey")
        self.label2.grid(row=7, column=1, padx=0, pady=5)
        self.button23 = Button(self.frame, text="Shi-Tomasi", font=("Bahnschrift Condensed", 14),width=15, bg="snow",
                               command=self.shi_tomasi)
        self.button23.grid(row=5, column=1, pady=5)
        self.button20 = Button(self.frame, text="Vincent", font=("Bahnschrift Condensed", 14), bg="snow", width=15,
                               command=self.vincent)
        self.button20.grid(row=6, column=0, pady=5)
        self.button21 = Button(self.frame, text="Canny", font=("Bahnschrift Condensed", 14), bg="snow", width=15,
                               command=self.canny)
        self.button21.grid(row=6, column=1, pady=5)


        self.image1 = self.solution.original()
        self.label3 = Label(self.frame, image=self.image1, bg="darkgrey")
        self.label3.grid(row=8, column=0, pady=10)

        self.image2 = self.solution.original()
        self.label4 = Label(self.frame, image=self.image2, bg="darkgrey")
        self.label4.grid(row=8, column=1, pady=10)



    def shi_tomasi(self):
        self.image2 = self.solution.shi_tomasi()
        self.label4.configure(image=self.image2)
        self.label4.image = self.image2


    def canny(self):
        self.image2 = self.solution.canny()
        self.label4.configure(image=self.image2)
        self.label4.image = self.image2

    def vincent(self):
        self.image2 = self.solution.vincent()
        self.label4.configure(image=self.image2)
        self.label4.image = self.image2

    def original_image(self):
        self.image1 = self.solution.original()
        self.label3.configure(image=self.image1)
        self.label3.image = self.image1

    def filt(self):
        self.image2 = self.solution.filt()
        self.label4.configure(image=self.image2)
        self.label4.image = self.image2

    def local_threshold(self):
        self.image1 = self.solution.local_threshold()
        self.label4.configure(image=self.image1)
        self.label4.image = self.image1

    def adaptive_threshold(self):
        self.image2 = self.solution.adaptive_threshold()
        self.label4.configure(image=self.image2)
        self.label4.image = self.image2

    def segmentation(self):
        self.image2 = self.solution.segmentation()
        self.label4.configure(image=self.image2)
        self.label4.image = self.image2

    def bilateral_filter(self):
        self.image2 = self.solution.bilateral_filter()
        self.label4.configure(image=self.image2)
        self.label4.image = self.image2

    def furie(self):
        self.image2 = self.solution.furie()
        self.label4.configure(image=self.image2)
        self.label4.image = self.image2

    def edge_detection(self):
        self.image2 = self.solution.edge_detection()
        self.label4.configure(image=self.image2)
        self.label4.image = self.image2

    def euclidean_distance(self):
        self.image2 = self.solution.euclidean_distance()
        self.label4.configure(image=self.image2)
        self.label4.image = self.image2

    def niblack(self):
        self.image2 = self.solution.niblack()
        self.label4.configure(image=self.image2)
        self.label4.image = self.image2


    def exit(self):
        self.master.destroy()


if __name__ == "__main__":
    root = Tk()
    root.title("Image Processing")
    root.geometry("1000x700")
    root.resizable(False, False)
    app = MainApp(root)
    root.mainloop()