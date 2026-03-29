#include <stdio.h>
#include "pico/stdlib.h"
#include "pico/stdio_usb.h" // allow you to use the usb seriel 


void pico_set_led(int pin_no, bool led_on){ // allow it to set as 1 or 0 
    gpio_put(pin_no,led_on);
}

const uint led_pins[] = {25, 13, 14, 15};

int main()
{
    stdio_init_all();
    // the initiase all pins as it only work for one 
    for (int i = 0; i < 4; i++) {
        gpio_init(led_pins[i]);
        gpio_set_dir(led_pins[i], GPIO_OUT);
        gpio_put(led_pins[i], 0);
    }

    while (true){

        pico_set_led(25, stdio_usb_connected());
        int user_input = getchar_timeout_usb(0);
        

        if (user_input == '0' ){
            pico_set_led(13,false);
            printf(BlueLedIsOff\n);
        }
        else if (user_input == '1'){
            pico_set_led(13,true);
            printf(BlueLedIsOn\n);
        }
        else if (user_input == '2'){
            pico_set_led(14,false);
            printf(RedLedIsOff\n);
        }
        else if (user_input == '3'){
            pico_set_led(14,true);
            printf(RedLedIsOn\n);
        }
        else if (user_input == '4'){
            pico_set_led(15,false);
            printf(YellowLedIsOff\n);
        }
        else if (user_input == '5'){
            pico_set_led(15,true);
            printf(YellowLedIsOn\n);
        }

        sleep_ms(10);

    }
}
