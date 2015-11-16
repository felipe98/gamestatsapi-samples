/// <reference path="pixi.min.js" />

var Game = function () {
    this._width = 1920;
    this._height = 1080;
    this._center = {
        x: Math.round(this._width / 2),
        y: Math.round(this._height / 2)
    };

    // Setup rendering
    this.renderer = new PIXI.autoDetectRenderer(this._width, this._height);
    document.body.appendChild(this.renderer.view);

    // main stage
    this.stage = PIXI.Stage();

    // game entities
    this.gameObjs = [];

    this.run();
};

Game.prototype = {
    run: function () {
        this.setupScene();
        this.setupMenu();

        requestAnimationFrame(this.tick.bind(this));
    },
    setupScene: function () {

    },
    setupMenu: function () {

    }
};