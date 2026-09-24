// ============================================================
//  IPQUEST ARCADE — Main Web Game Engine & Interactive System
//  Features: Web Audio Synthesizer, Confetti FX, Player Progression,
//            3D Perspective Card Physics, Toast Alerts & Mini-Game
// ============================================================

window.IPQuestAudio = (function () {
    let audioCtx = null;
    let sfxEnabled = true;

    // Load persistent SFX state
    if (localStorage.getItem('ipquest_sfx_muted') === 'true') {
        sfxEnabled = false;
    }

    function getAudioContext() {
        if (!audioCtx) {
            const AudioContextClass = window.AudioContext || window.webkitAudioContext;
            if (AudioContextClass) {
                audioCtx = new AudioContextClass();
            }
        }
        if (audioCtx && audioCtx.state === 'suspended') {
            audioCtx.resume();
        }
        return audioCtx;
    }

    function playTone(freq, type, duration, startVol = 0.15, endVol = 0.001) {
        if (!sfxEnabled) return;
        try {
            const ctx = getAudioContext();
            if (!ctx) return;

            const osc = ctx.createOscillator();
            const gain = ctx.createGain();

            osc.type = type;
            osc.frequency.setValueAtTime(freq, ctx.currentTime);

            gain.gain.setValueAtTime(startVol, ctx.currentTime);
            gain.gain.exponentialRampToValueAtTime(endVol, ctx.currentTime + duration);

            osc.connect(gain);
            gain.connect(ctx.destination);

            osc.start();
            osc.stop(ctx.currentTime + duration);
        } catch (e) {
            console.warn('Audio play error:', e);
        }
    }

    function playArpeggio(notes, type, noteDuration = 0.08) {
        if (!sfxEnabled) return;
        notes.forEach((freq, idx) => {
            setTimeout(() => {
                playTone(freq, type, noteDuration * 1.5, 0.2, 0.001);
            }, idx * noteDuration * 1000);
        });
    }

    return {
        isMuted: function () { return !sfxEnabled; },
        toggleMute: function () {
            sfxEnabled = !sfxEnabled;
            localStorage.setItem('ipquest_sfx_muted', !sfxEnabled);
            return sfxEnabled;
        },
        playHover: function () {
            playTone(523.25, 'sine', 0.05, 0.05, 0.001); // C5 quick blip
        },
        playClick: function () {
            playTone(880, 'triangle', 0.08, 0.15, 0.001); // A5 arcade tap
        },
        playCorrect: function () {
            // Major chord C5 -> E5 -> G5 -> C6 arpeggio
            playArpeggio([523.25, 659.25, 783.99, 1046.50], 'triangle', 0.07);
        },
        playWrong: function () {
            // Low sawtooth dissonance F3 -> D3
            playTone(174.61, 'sawtooth', 0.25, 0.25, 0.001);
            setTimeout(() => playTone(146.83, 'sawtooth', 0.3, 0.25, 0.001), 100);
        },
        playCombo: function (multiplier) {
            // Power-up pitch riser based on multiplier
            const baseFreq = 440 * (1 + multiplier * 0.25);
            playArpeggio([baseFreq, baseFreq * 1.25, baseFreq * 1.5], 'sine', 0.06);
        },
        playPowerup: function () {
            // Sci-fi laser sweep
            if (!sfxEnabled) return;
            try {
                const ctx = getAudioContext();
                if (!ctx) return;
                const osc = ctx.createOscillator();
                const gain = ctx.createGain();
                osc.type = 'sawtooth';
                osc.frequency.setValueAtTime(300, ctx.currentTime);
                osc.frequency.exponentialRampToValueAtTime(1400, ctx.currentTime + 0.2);
                gain.gain.setValueAtTime(0.18, ctx.currentTime);
                gain.gain.exponentialRampToValueAtTime(0.001, ctx.currentTime + 0.22);
                osc.connect(gain);
                gain.connect(ctx.destination);
                osc.start();
                osc.stop(ctx.currentTime + 0.22);
            } catch (e) {}
        },
        playTick: function () {
            playTone(1000, 'square', 0.03, 0.04, 0.001);
        },
        playFanfare: function () {
            // 8-bit level victory theme: C5 -> E5 -> G5 -> C6 -> E6
            playArpeggio([523.25, 659.25, 783.99, 1046.50, 1318.51], 'square', 0.09);
        }
    };
})();


// ============================================================
//  CONFETTI CANVASES ENGINE
// ============================================================
window.IPQuestConfetti = (function () {
    let canvas = null;
    let ctx = null;
    let particles = [];
    let animId = null;

    function init() {
        canvas = document.getElementById('confetti-canvas');
        if (!canvas) return;
        ctx = canvas.getContext('2d');
        resize();
        window.addEventListener('resize', resize);
    }

    function resize() {
        if (!canvas) return;
        canvas.width = window.innerWidth;
        canvas.height = window.innerHeight;
    }

    function burst(originX, originY, count = 70) {
        if (!canvas) init();
        if (!canvas || !ctx) return;

        const colors = ['#00f2fe', '#9d4edd', '#ff2a85', '#ffd700', '#00ff87', '#ffffff'];
        const startX = originX || canvas.width / 2;
        const startY = originY || canvas.height / 3;

        for (let i = 0; i < count; i++) {
            const angle = Math.random() * Math.PI * 2;
            const speed = Math.random() * 12 + 4;
            particles.push({
                x: startX,
                y: startY,
                vx: Math.cos(angle) * speed,
                vy: Math.sin(angle) * speed - 3,
                size: Math.random() * 8 + 4,
                color: colors[Math.floor(Math.random() * colors.length)],
                rotation: Math.random() * 360,
                rotSpeed: (Math.random() - 0.5) * 10,
                alpha: 1,
                decay: Math.random() * 0.015 + 0.01,
                shape: Math.random() > 0.4 ? 'rect' : 'circle'
            });
        }

        if (!animId) {
            animLoop();
        }
    }

    function animLoop() {
        if (!ctx || !canvas) return;
        ctx.clearRect(0, 0, canvas.width, canvas.height);

        for (let i = particles.length - 1; i >= 0; i--) {
            const p = particles[i];
            p.x += p.vx;
            p.y += p.vy;
            p.vy += 0.25; // gravity
            p.vx *= 0.98; // drag
            p.rotation += p.rotSpeed;
            p.alpha -= p.decay;

            if (p.alpha <= 0) {
                particles.splice(i, 1);
                continue;
            }

            ctx.save();
            ctx.globalAlpha = Math.max(0, p.alpha);
            ctx.translate(p.x, p.y);
            ctx.rotate((p.rotation * Math.PI) / 180);
            ctx.fillStyle = p.color;

            if (p.shape === 'rect') {
                ctx.fillRect(-p.size / 2, -p.size / 2, p.size, p.size * 1.4);
            } else {
                ctx.beginPath();
                ctx.arc(0, 0, p.size / 2, 0, Math.PI * 2);
                ctx.fill();
            }

            ctx.restore();
        }

        if (particles.length > 0) {
            animId = requestAnimationFrame(animLoop);
        } else {
            animId = null;
            ctx.clearRect(0, 0, canvas.width, canvas.height);
        }
    }

    return {
        burst: burst
    };
})();


// ============================================================
//  GLOBAL GAME STATE & HUD MANAGER
// ============================================================
window.IPQuestGame = (function () {
    const STATE_KEY = 'ipquest_game_data';

    let state = {
        totalXP: 0,
        quizzesCompleted: 0,
        perfectScores: 0,
        maxCombo: 0,
        titleOverride: '',
        topicStars: {} // e.g. {1: 3, 2: 2}
    };

    function loadState() {
        try {
            const raw = localStorage.getItem(STATE_KEY);
            if (raw) {
                const parsed = JSON.parse(raw);
                state = Object.assign(state, parsed);
            }
        } catch (e) {
            console.warn('Failed loading game state from localStorage', e);
        }
    }

    function saveState() {
        try {
            localStorage.setItem(STATE_KEY, JSON.stringify(state));
            updateHUD();
        } catch (e) {}
    }

    function getLevelInfo(xp) {
        const level = Math.floor(xp / 100) + 1;
        const currentXPInLevel = xp % 100;
        let defaultTitle = 'Novice Detective';
        if (level >= 5) defaultTitle = 'IP Archmage';
        else if (level === 4) defaultTitle = 'Patent Titan';
        else if (level === 3) defaultTitle = 'IP Specialist';
        else if (level === 2) defaultTitle = 'Investigator';

        return {
            level: level,
            currentXP: currentXPInLevel,
            nextLevelXP: 100,
            percent: Math.min(100, currentXPInLevel),
            title: state.titleOverride || defaultTitle
        };
    }

    function updateHUD() {
        const levelBadge = document.getElementById('hud-level-badge');
        const playerTitle = document.getElementById('hud-player-title');
        const xpText = document.getElementById('hud-xp-text');
        const xpFill = document.getElementById('hud-xp-fill');

        if (!levelBadge) return;

        const info = getLevelInfo(state.totalXP);

        levelBadge.textContent = `LVL ${info.level}`;
        if (playerTitle) playerTitle.textContent = info.title;
        if (xpText) xpText.textContent = `${state.totalXP} XP`;
        if (xpFill) xpFill.style.width = `${info.percent}%`;
    }

    function addXP(amount) {
        const oldLevel = getLevelInfo(state.totalXP).level;
        state.totalXP += amount;
        const newLevel = getLevelInfo(state.totalXP).level;

        saveState();

        if (newLevel > oldLevel) {
            window.IPQuestAudio.playFanfare();
            window.IPQuestConfetti.burst();
            showToast(`🎉 LEVEL UP! You reached Level ${newLevel}!`, 'gold');
        }
    }

    function showToast(message, type = 'info') {
        const container = document.getElementById('game-toast-container');
        if (!container) return;

        const toast = document.createElement('div');
        toast.className = `game-toast game-toast-${type}`;
        toast.innerHTML = `
            <span class="toast-icon">${type === 'gold' ? '🏆' : type === 'success' ? '⚡' : '🎮'}</span>
            <span class="toast-msg">${message}</span>
        `;

        container.appendChild(toast);

        setTimeout(() => {
            toast.classList.add('show');
        }, 20);

        setTimeout(() => {
            toast.classList.remove('show');
            setTimeout(() => toast.remove(), 400);
        }, 3500);
    }

    // Initialize on script load
    loadState();

    return {
        getState: function () { return state; },
        getLevelInfo: getLevelInfo,
        addXP: addXP,
        recordQuizComplete: function (topicId, score, total, xpEarned, maxStreak) {
            state.quizzesCompleted += 1;
            if (score === total) state.perfectScores += 1;
            if (maxStreak > state.maxCombo) state.maxCombo = maxStreak;

            // Calculate stars (3 stars for 100%, 2 stars for >= 66%, 1 star for >0)
            let stars = 0;
            if (score === total) stars = 3;
            else if (score >= total * 0.66) stars = 2;
            else if (score > 0) stars = 1;

            if (!state.topicStars[topicId] || state.topicStars[topicId] < stars) {
                state.topicStars[topicId] = stars;
            }

            addXP(xpEarned);
            saveState();
        },
        setTitle: function (newTitle) {
            state.titleOverride = newTitle;
            saveState();
        },
        showToast: showToast,
        updateHUD: updateHUD
    };
})();


// ============================================================
//  3D PERSPECTIVE CARD TILT ENGINE
// ============================================================
function init3DTiltCards() {
    const selector = '.glass-card, .topic-card, .feature-card, .question-card, .topic-detail-card, .mini-game-card';
    const cards = document.querySelectorAll(selector);

    cards.forEach(card => {
        card.addEventListener('mousemove', function (e) {
            const rect = card.getBoundingClientRect();
            const x = e.clientX - rect.left;
            const y = e.clientY - rect.top;

            const centerX = rect.width / 2;
            const centerY = rect.height / 2;

            const rotateX = ((y - centerY) / centerY) * -6; // max 6 deg
            const rotateY = ((x - centerX) / centerX) * 6;

            card.style.transform = `perspective(1000px) rotateX(${rotateX}deg) rotateY(${rotateY}deg) translateY(-6px)`;
        });

        card.addEventListener('mouseleave', function () {
            card.style.transform = 'perspective(1000px) rotateX(0deg) rotateY(0deg) translateY(0px)';
        });
    });
}


// ============================================================
//  FLOATING CONSTELLATION BACKGROUND & INITIALIZERS
// ============================================================
(function () {
    // --- Canvas Particles ---
    const canvas = document.getElementById('particles-canvas');
    if (canvas) {
        const ctx = canvas.getContext('2d');
        let particles = [];
        const CONNECTION_DISTANCE = 140;
        const PARTICLE_COUNT_FACTOR = 0.00006;

        function resize() {
            canvas.width = window.innerWidth;
            canvas.height = window.innerHeight;
            initParticles();
        }

        function initParticles() {
            const area = canvas.width * canvas.height;
            const count = Math.max(30, Math.min(90, Math.floor(area * PARTICLE_COUNT_FACTOR)));
            particles = [];
            for (let i = 0; i < count; i++) {
                particles.push({
                    x: Math.random() * canvas.width,
                    y: Math.random() * canvas.height,
                    vx: (Math.random() - 0.5) * 0.35,
                    vy: (Math.random() - 0.5) * 0.35,
                    radius: Math.random() * 2 + 1,
                    alpha: Math.random() * 0.4 + 0.15,
                    hue: Math.random() > 0.5 ? 240 + Math.random() * 30 : 260 + Math.random() * 40
                });
            }
        }

        function drawParticle(p) {
            ctx.beginPath();
            ctx.arc(p.x, p.y, p.radius, 0, Math.PI * 2);
            ctx.fillStyle = `hsla(${p.hue}, 70%, 70%, ${p.alpha})`;
            ctx.fill();

            ctx.beginPath();
            ctx.arc(p.x, p.y, p.radius * 3, 0, Math.PI * 2);
            ctx.fillStyle = `hsla(${p.hue}, 70%, 70%, ${p.alpha * 0.15})`;
            ctx.fill();
        }

        function drawConnections() {
            for (let i = 0; i < particles.length; i++) {
                for (let j = i + 1; j < particles.length; j++) {
                    const dx = particles[i].x - particles[j].x;
                    const dy = particles[i].y - particles[j].y;
                    const dist = Math.sqrt(dx * dx + dy * dy);
                    if (dist < CONNECTION_DISTANCE) {
                        const opacity = (1 - dist / CONNECTION_DISTANCE) * 0.12;
                        ctx.beginPath();
                        ctx.moveTo(particles[i].x, particles[i].y);
                        ctx.lineTo(particles[j].x, particles[j].y);
                        ctx.strokeStyle = `rgba(167, 139, 250, ${opacity})`;
                        ctx.lineWidth = 0.5;
                        ctx.stroke();
                    }
                }
            }
        }

        function animate() {
            ctx.clearRect(0, 0, canvas.width, canvas.height);
            drawConnections();
            particles.forEach(p => {
                p.x += p.vx;
                p.y += p.vy;
                if (p.x < -10) p.x = canvas.width + 10;
                if (p.x > canvas.width + 10) p.x = -10;
                if (p.y < -10) p.y = canvas.height + 10;
                if (p.y > canvas.height + 10) p.y = -10;
                drawParticle(p);
            });
            requestAnimationFrame(animate);
        }

        resize();
        animate();
        window.addEventListener('resize', resize);
    }

    // --- DOM Loaded Handlers ---
    document.addEventListener('DOMContentLoaded', function () {
        // Sync HUD State
        window.IPQuestGame.updateHUD();

        // Sound FX Toggle Event
        const sfxBtn = document.getElementById('sfx-toggle-btn');
        const sfxIcon = document.getElementById('sfx-icon');
        const sfxText = document.getElementById('sfx-text');

        function updateSfxButtonUI() {
            const isMuted = window.IPQuestAudio.isMuted();
            if (sfxIcon) sfxIcon.textContent = isMuted ? '🔇' : '🔊';
            if (sfxText) sfxText.textContent = isMuted ? 'SFX OFF' : 'SFX ON';
            if (sfxBtn) {
                if (isMuted) sfxBtn.classList.add('muted');
                else sfxBtn.classList.remove('muted');
            }
        }

        updateSfxButtonUI();

        if (sfxBtn) {
            sfxBtn.addEventListener('click', function () {
                window.IPQuestAudio.toggleMute();
                updateSfxButtonUI();
                if (!window.IPQuestAudio.isMuted()) {
                    window.IPQuestAudio.playClick();
                }
            });
        }

        // Global Button Click SFX & Hover SFX
        document.addEventListener('mouseover', function (e) {
            if (e.target.closest('button, a, .answer-option, .topic-card, .feature-card, .sort-bin, .sort-card')) {
                window.IPQuestAudio.playHover();
            }
        });

        document.addEventListener('click', function (e) {
            if (e.target.closest('button, a, .answer-option')) {
                window.IPQuestAudio.playClick();
            }
        });

        // Mobile Nav Toggle
        const toggle = document.querySelector('.nav-toggle');
        const navLinks = document.querySelector('.nav-links');
        if (toggle && navLinks) {
            toggle.addEventListener('click', () => {
                navLinks.classList.toggle('open');
            });
            navLinks.querySelectorAll('a').forEach(link => {
                link.addEventListener('click', () => {
                    navLinks.classList.remove('open');
                });
            });
        }

        // Initialize 3D Perspective Tilt on Cards
        init3DTiltCards();
    });
})();

