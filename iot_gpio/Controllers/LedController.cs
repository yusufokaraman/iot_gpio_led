﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Linq;
using System.Threading.Tasks;

namespace iot_gpio.Controllers
{
    public class LedController : Controller
    {
        /// <summary>
        /// We give the pin number to which we connect the led.
        /// </summary>
        private const int LedPin = 17;
        private readonly GpioController _gpioController;

        /// <summary>
        /// We define the constructor because define our pin manager and the pin we will use here
        /// </summary>
        /// <param name="gpioController"></param>
        public LedController(GpioController gpioController)
        {
            _gpioController = gpioController;
            _gpioController.OpenPin(LedPin, PinMode.Output);
        }
        /// <summary>
        /// Index method
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The method written to turn on the LED
        /// </summary>
        /// <returns></returns>
        public IActionResult LedAc()
        {
            //verilmiş olan pini voltaj verecek şekilde değiştiriyoruz
            _gpioController.Write(LedPin, PinValue.High);
            //kullanıcıya bilgi vermek için bir mesaj yazıyoruz.
            ViewBag.LedDurumu = "Led Açık!";

            return View("Index");
        }

        /// <summary>
        /// Method written to turn off the LED
        /// </summary>
        /// <returns></returns>
        public IActionResult LedKapat()
        {
            //verilmiş olan pini voltajı kesecek şekilde değiştiriyoruz
            _gpioController.Write(LedPin, PinValue.Low);
            //kullanıcıya bilgi vermek için bir mesaj yazıyoruz.
            ViewBag.LedDurumu = "Led Kapalı!";

            return View("Index");
        }
    }
}
